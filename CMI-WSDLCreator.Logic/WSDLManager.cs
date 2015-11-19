using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;


namespace CMI_WSDLCreator.Logic
{
    /// <summary>
    /// 
    /// </summary>
    public enum ServiceType
    {
        Entity,
        Process,
        Task,
        Application
    }

    /// <summary>
    /// 
    /// </summary>
    public class WSDLManager
    {
        #region Attributes
        private List<Capacity> methods;
        private List<BussinessObject> bussinesObjects;
        private string serviceName;
        private ServiceType type;
        private string servicePref;
        private string wsdlsPath;
        private string domain;
        private string documentation;
        private List<string> containers;
        private bool useDirectory;
        #endregion

        #region Properties

        public bool UseDirectory
        {
            get { return useDirectory; }
            set { useDirectory = value; }
        }

        public string WsdlsPath
        {
            get { return wsdlsPath; }
            set { wsdlsPath = value; }
        }

        public List<BussinessObject> BussinesObjects
        {
            get { return bussinesObjects; }
            set { bussinesObjects = value; }
        }

        public List<Capacity> Methods
        {
            get { return methods; }
            set { methods = value; }
        }

        public string Documentation
        {
            get { return documentation; }
            set { documentation = value; }
        }

        public string Domain
        {
            get { return domain; }
            set { domain = value; }
        }

        public ServiceType Type
        {
            get { return type; }
            set { type = value; }
        }

        public string ServiceName
        {
            get { return serviceName; }
            set { serviceName = value; }
        }

        public WSDLManager()
        {
            this.methods = new List<Capacity>();
            this.bussinesObjects = new List<BussinessObject>();
            this.containers = new List<string>();
            this.useDirectory = true;
        }

        public void CreateWSDL()
        {
            servicePref = GetServicePrefix();

            if (String.IsNullOrWhiteSpace(this.wsdlsPath) || String.IsNullOrEmpty(this.wsdlsPath) || this.wsdlsPath == null )
            {
                wsdlsPath = ConfigurationManager.AppSettings["WSDLS_PATH"];
            }
            
            this.containers.Clear();
            CreateXMLWSDL();
        }
        #endregion

        #region Create WSDL
        private void CreateXMLWSDL()
        {
            #region File Creation

            string directoryPath = "";
            string wsdlPath= "";
          
            directoryPath = String.Format(@"{0}\{1}{2}\", this.wsdlsPath, this.servicePref, this.ServiceName);

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            wsdlPath = string.Format(@"{0}\{1}{2}.wsdl", directoryPath, this.servicePref, this.ServiceName);

            if (System.IO.File.Exists(wsdlPath))
            {
                System.IO.File.Delete(wsdlPath);
            }


            #endregion

            #region Definitions

            string fullServiceName = string.Format("{0}{1}", this.servicePref, this.ServiceName);
            string targetNamespace = string.Format(@"http://www.imbanaco.com/servicios/{0}/{1}/", this.domain, fullServiceName);

            XmlDocument doc = new XmlDocument();
            XmlNode docNode = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            doc.AppendChild(docNode);

            string wsdlURI = "http://schemas.xmlsoap.org/wsdl/";


            string soapURI = "";

            if(this.type == ServiceType.Application)
                soapURI = "http://schemas.xmlsoap.org/wsdl/soap12/";
            else
                soapURI = "http://schemas.xmlsoap.org/wsdl/soap/";
            

            string xsdURI = "http://www.w3.org/2001/XMLSchema";

            string cttURI = "http://www.imbanaco.com/schema/ContextoTransaccionalTipo";
            string crtURI = "http://www.imbanaco.com/schema/ContextoRespuestaTipo";
            string falloURI = "http://www.imbanaco.com/schema/FalloTipo";

            string falloAppURI = "http://www.imbanaco.com/schema/MsjServicioFalloTipo";

            XmlElement definitions = doc.CreateElement("wsdl", "definitions", wsdlURI);

            definitions.SetAttribute("name", fullServiceName);
            definitions.SetAttribute("targetNamespace", targetNamespace);


            if (this.type == ServiceType.Application)
                definitions.SetAttribute("xmlns:soap12", soapURI);
            else
                definitions.SetAttribute("xmlns:soap", soapURI);

            definitions.SetAttribute("xmlns:tns", targetNamespace);
            definitions.SetAttribute("xmlns:xsd", xsdURI);

            XmlElement documentation = doc.CreateElement("wsdl", "documentation", wsdlURI);
            documentation.InnerText = this.documentation;
            definitions.AppendChild(documentation);

            XmlElement types = doc.CreateElement("wsdl", "types", wsdlURI);

            XmlElement schema = doc.CreateElement("xsd", "schema", xsdURI);
            schema.SetAttribute("targetNamespace", targetNamespace);
            schema.SetAttribute("xmlns:ctt", cttURI);
            schema.SetAttribute("xmlns:crt", crtURI);
            
            if (this.type == ServiceType.Application)
            {
                schema.SetAttribute("xmlns:msjfallo", falloAppURI);
            }
            else 
            {
                schema.SetAttribute("xmlns:fallo", falloURI);
            }


            for (int i = 0; i < this.BussinesObjects.Count; i++)
            {
                var boRel = this.BussinesObjects[i];
                schema.SetAttribute(string.Format("xmlns:this{0}", i + 1), boRel.NameSpace);
                boRel.Prefix = string.Format("this{0}", i + 1);
            }

            XmlElement import = doc.CreateElement("xsd", "import", xsdURI);
            import.SetAttribute("namespace", "http://www.imbanaco.com/schema/ContextoTransaccionalTipo");
            import.SetAttribute("schemaLocation", "../../../../../Comunes/EntidadesNegocio/V1.0/ContextoTransaccionalTipo.xsd");
            schema.AppendChild(import);

            import = doc.CreateElement("xsd", "import", xsdURI);
            import.SetAttribute("namespace", "http://www.imbanaco.com/schema/FalloTipo");
            import.SetAttribute("schemaLocation", "../../../../../Comunes/EntidadesNegocio/V1.0/FalloTipo.xsd");
            schema.AppendChild(import);

            import = doc.CreateElement("xsd", "import", xsdURI);
            import.SetAttribute("namespace", "http://www.imbanaco.com/schema/ContextoRespuestaTipo");
            import.SetAttribute("schemaLocation", "../../../../../Comunes/EntidadesNegocio/V1.0/ContextoRespuestaTipo.xsd");
            schema.AppendChild(import);

            if (this.type == ServiceType.Application)
            {
                import = doc.CreateElement("xsd", "import", xsdURI);
                import.SetAttribute("namespace", "http://www.imbanaco.com/schema/MsjServicioFalloTipo");
                import.SetAttribute("schemaLocation", "../../../../../Comunes/EntidadesNegocio/V1.0/MsjServicioFalloTipo.xsd");
                schema.AppendChild(import);
            }

            foreach (var boRel in this.BussinesObjects)
            {
                import = doc.CreateElement("xsd", "import", xsdURI);
                import.SetAttribute("namespace", boRel.NameSpace);

                if (this.type == ServiceType.Application)
                {
                    if(boRel.IsExtern)
                        import.SetAttribute("schemaLocation", string.Format("../../../../../{1}/EntidadesNegocio/{0}/V1.0/{0}.xsd", boRel.Name, boRel.Domain));
                    else
                        import.SetAttribute("schemaLocation", string.Format("../../../../EntidadesNegocio/{0}/V1.0/{0}.xsd", boRel.Name));
                }
                else
                {
                    if (boRel.IsExtern)
                    {
                        import.SetAttribute("schemaLocation", string.Format("../../../../../{1}/EntidadesNegocioIntegracion/{0}/V1.0/{0}.xsd", boRel.Name, boRel.Domain));
                    }
                    else 
                    {
                        import.SetAttribute("schemaLocation", string.Format("../../../../EntidadesNegocioIntegracion/{0}/V1.0/{0}.xsd", boRel.Name));
                    }
                    
                }

                schema.AppendChild(import);
            }

            #endregion

            #region Types

            XmlElement elemento = null;

            foreach (var item in this.methods)
            {
                #region Message Elements
                CreateElementMethod(elemento, doc, xsdURI, item.Name, schema, "");
                CreateElementMethod(elemento, doc, xsdURI, item.Name, schema, "Resp");
                CreateElementMethod(elemento, doc, xsdURI, item.Name, schema, "Fallo");

                CreateComplexTypeMethod(elemento, doc, xsdURI, item.Name, schema, "Tipo", "Sol");
                CreateComplexTypeMethod(elemento, doc, xsdURI, item.Name, schema, "RespTipo", "Resp");

                if (this.type != ServiceType.Application)
                {
                    CreateComplexTypeMethod(elemento, doc, xsdURI, item.Name, schema, "FalloTipo", "Fallo");
                }                

                #endregion

                #region Input Message
                elemento = doc.CreateElement("xsd", "complexType", xsdURI); ;
                elemento.SetAttribute("name", string.Format("Msj{0}SolTipo", item.Name));

                XmlElement sequence = doc.CreateElement("xsd", "sequence", xsdURI);

                XmlElement ctt = doc.CreateElement("xsd", "element", xsdURI);
                ctt.SetAttribute("name", "contextoTransaccional");
                ctt.SetAttribute("type", "ctt:ContextoTransaccionalTipo");
                ctt.SetAttribute("minOccurs", "1");
                ctt.SetAttribute("maxOccurs", "1");
                ctt.InnerText = "";
                sequence.AppendChild(ctt);

                XmlElement param = null;

                XmlElement collecion = null;
                XmlElement seqCollecion = null;
                XmlElement boResp = null;

                foreach (var parameter in item.ParametersIn)
                {
                    if (parameter.Container != null && parameter.Container.Length > 0)
                    {
                        //Crea el elemento de tipo del contenedor
                        boResp = doc.CreateElement("xsd", "element", xsdURI);
                        boResp.SetAttribute("name", parameter.ListName);
                        boResp.SetAttribute("type", string.Format("tns:{0}", parameter.Container));
                        boResp.SetAttribute("minOccurs", "1");
                        boResp.SetAttribute("maxOccurs", "1");
                        boResp.InnerText = "";
                        sequence.AppendChild(boResp);
                        elemento.AppendChild(sequence);

                        if (!this.containers.Contains(parameter.Container))
                        {
                            //Crea el contenedor
                            collecion = doc.CreateElement("xsd", "complexType", xsdURI); ;
                            collecion.SetAttribute("name", parameter.Container);
                            seqCollecion = doc.CreateElement("xsd", "sequence", xsdURI);

                            //Crea la lista dentro del contenedor
                            XmlElement list = doc.CreateElement("xsd", "element", xsdURI);
                            list.SetAttribute("name", parameter.Name);

                            if (parameter.Obj != null)
                            {
                                list.SetAttribute("type", string.Format("{0}:{1}", parameter.Obj.Prefix, parameter.Obj.Name));
                            }
                            else
                            {
                                list.SetAttribute("type", string.Format("xsd:{0}", parameter.Type));
                            }

                            list.SetAttribute("minOccurs", parameter.MinOccurs);
                            list.SetAttribute("maxOccurs", parameter.MaxOccurs);
                            list.InnerText = "";

                            seqCollecion.AppendChild(list);
                            collecion.AppendChild(seqCollecion);

                            schema.AppendChild(collecion);

                            this.containers.Add(parameter.Container);
                        }
                    }
                    else
                    {
                        param = doc.CreateElement("xsd", "element", xsdURI);
                        param.SetAttribute("name", parameter.Name);

                        if (parameter.Obj != null)
                        {
                            param.SetAttribute("type", string.Format("{0}:{1}", parameter.Obj.Prefix, parameter.Obj.Name));
                        }
                        else
                        {
                            param.SetAttribute("type", string.Format("xsd:{0}", parameter.Type));
                        }

                        param.SetAttribute("minOccurs", parameter.MinOccurs);
                        param.SetAttribute("maxOccurs", parameter.MaxOccurs);

                        sequence.AppendChild(param);
                    }
                }

                elemento.AppendChild(sequence);
                schema.AppendChild(elemento);
                #endregion

                #region Output Message
                elemento = doc.CreateElement("xsd", "complexType", xsdURI); ;
                elemento.SetAttribute("name", string.Format("Msj{0}RespTipo", item.Name));

                sequence = doc.CreateElement("xsd", "sequence", xsdURI);

                XmlElement ctr = doc.CreateElement("xsd", "element", xsdURI);
                ctr.SetAttribute("name", "contextoRespuesta");
                ctr.SetAttribute("type", "crt:ContextoRespuestaTipo");
                ctr.SetAttribute("minOccurs", "1");
                ctr.SetAttribute("maxOccurs", "1");
                ctr.InnerText = "";

                sequence.AppendChild(ctr);
                elemento.AppendChild(sequence);


                foreach (var parameter in item.ParametersOut)
                {
                    if (parameter.Container != null && parameter.Container.Length > 0)
                    {
                        //Crea el elemento de tipo del contenedor
                        boResp = doc.CreateElement("xsd", "element", xsdURI);
                        boResp.SetAttribute("name", parameter.ListName);
                        boResp.SetAttribute("type", string.Format("tns:{0}", parameter.Container));
                        boResp.SetAttribute("minOccurs", "0");
                        boResp.SetAttribute("maxOccurs", "1");
                        boResp.InnerText = "";
                        sequence.AppendChild(boResp);
                        elemento.AppendChild(sequence);

                        if (!this.containers.Contains(parameter.Container))
                        {
                            //Crea el contenedor
                            collecion = doc.CreateElement("xsd", "complexType", xsdURI); ;
                            collecion.SetAttribute("name", parameter.Container);
                            seqCollecion = doc.CreateElement("xsd", "sequence", xsdURI);

                            //Crea la lista dentro del contenedor
                            XmlElement list = doc.CreateElement("xsd", "element", xsdURI);
                            list.SetAttribute("name", parameter.Name);

                            if (parameter.Obj != null)
                            {
                                list.SetAttribute("type", string.Format("{0}:{1}", parameter.Obj.Prefix, parameter.Obj.Name));
                            }
                            else
                            {
                                list.SetAttribute("type", string.Format("xsd:{0}", parameter.Type));
                            }

                            list.SetAttribute("minOccurs", parameter.MinOccurs);
                            list.SetAttribute("maxOccurs", parameter.MaxOccurs);
                            list.InnerText = "";

                            seqCollecion.AppendChild(list);
                            collecion.AppendChild(seqCollecion);

                            schema.AppendChild(collecion);

                            this.containers.Add(parameter.Container);
                        }
                    }
                    else
                    {
                        param = doc.CreateElement("xsd", "element", xsdURI);
                        param.SetAttribute("name", parameter.Name);

                        if (parameter.Obj != null)
                        {
                            param.SetAttribute("type", string.Format("{0}:{1}", parameter.Obj.Prefix, parameter.Obj.Name));
                        }
                        else
                        {
                            param.SetAttribute("type", string.Format("xsd:{0}", parameter.Type));
                        }

                        param.SetAttribute("minOccurs", parameter.MinOccurs);
                        param.SetAttribute("maxOccurs", parameter.MaxOccurs);

                        sequence.AppendChild(param);
                    }

                }

                elemento.AppendChild(sequence);
                schema.AppendChild(elemento);

                #endregion

                #region Fail Message

                if(type != ServiceType.Application)                
                {   
                    elemento = doc.CreateElement("xsd", "complexType", xsdURI); ;
                    elemento.SetAttribute("name", string.Format("Msj{0}FalloTipo", item.Name));

                    sequence = doc.CreateElement("xsd", "sequence", xsdURI);

                    XmlElement fallo = doc.CreateElement("xsd", "element", xsdURI);
                    fallo.SetAttribute("name", "fallo");
                    fallo.SetAttribute("type", "fallo:FalloTipo");
                    fallo.SetAttribute("minOccurs", "1");
                    fallo.SetAttribute("maxOccurs", "1");
                    fallo.InnerText = "";

                    sequence.AppendChild(fallo);
                    elemento.AppendChild(sequence);
                    schema.AppendChild(elemento);
                }

                #endregion
            }

            types.AppendChild(schema);
            definitions.AppendChild(types);

            #endregion

            #region Messages
            CreateMessages(doc, wsdlURI, definitions);
            #endregion

            #region PortType
            CreatePortTypeSection(fullServiceName, doc, wsdlURI, definitions);
            #endregion

            #region Binding
            CreateBindingSection(fullServiceName, targetNamespace, doc, wsdlURI, definitions, soapURI);
            #endregion

            #region Service
            CreateServiceSection(fullServiceName, targetNamespace, doc, wsdlURI, soapURI, definitions);

            doc.Save(wsdlPath);
            #endregion

            this.SaveMetadata();
            this.SaveWSRRFile();
        }
        #endregion

        #region Methods
              
        private void CreateElementMethod(XmlElement elemento, XmlDocument doc, string xsdURI, string methodName, XmlElement schema, string kind)
        {

            if (this.type == ServiceType.Application && kind == "Fallo")
            {
                elemento = doc.CreateElement("xsd", "element", xsdURI);
                elemento.SetAttribute("name", string.Format("{0}{1}", methodName, kind));
                elemento.SetAttribute("type", string.Format("msjfallo:MsjServicioFalloTipo", methodName, kind));
                schema.AppendChild(elemento);
            }
            else 
            {
                elemento = doc.CreateElement("xsd", "element", xsdURI);
                elemento.SetAttribute("name", string.Format("{0}{1}", methodName, kind));
                elemento.SetAttribute("type", string.Format("tns:{0}{1}Tipo", methodName, kind));
                schema.AppendChild(elemento);
            }
        }

        private void CreateComplexTypeMethod(XmlElement elemento, XmlDocument doc, string xsdURI, string methodName, XmlElement schema, string kind, string messageSuffix)
        {
            elemento = doc.CreateElement("xsd", "complexType", xsdURI);
            elemento.SetAttribute("name", string.Format("{0}{1}", methodName, kind));

            XmlElement sequence = doc.CreateElement("xsd", "sequence", xsdURI);
            XmlElement messsage = null;
                       
            messsage = doc.CreateElement("xsd", "element", xsdURI);
            messsage.SetAttribute("name", string.Format("msj{0}{1}", methodName, messageSuffix));
            messsage.SetAttribute("type", string.Format("tns:Msj{0}{1}Tipo", methodName, messageSuffix));
            messsage.SetAttribute("minOccurs", "1");
            messsage.SetAttribute("maxOccurs", "1");
            messsage.InnerText = "";
           
            sequence.AppendChild(messsage);
            elemento.AppendChild(sequence);
            schema.AppendChild(elemento);
        }

        private void CreateMessages(XmlDocument doc, string wsdlURI, XmlElement definitions)
        {
            XmlElement message, messageResp, messageFail, wsdlPart;
            string varMessage = "message";

            //Mensajes
            foreach (var item in this.methods)
            {
                message = doc.CreateElement("wsdl", varMessage, wsdlURI);
                message.SetAttribute("name", item.Name);

                wsdlPart = doc.CreateElement("wsdl", "part", wsdlURI);
                wsdlPart.SetAttribute("element", string.Format("tns:{0}", item.Name));
                wsdlPart.SetAttribute("name", item.Name);

                message.AppendChild(wsdlPart);
                definitions.AppendChild(message);

                messageResp = doc.CreateElement("wsdl", varMessage, wsdlURI);
                messageResp.SetAttribute("name", string.Format("{0}Resp", item.Name));

                wsdlPart = doc.CreateElement("wsdl", "part", wsdlURI);
                wsdlPart.SetAttribute("element", string.Format("tns:{0}Resp", item.Name));
                wsdlPart.SetAttribute("name", string.Format("{0}Resp", item.Name));

                messageResp.AppendChild(wsdlPart);
                definitions.AppendChild(messageResp);

                messageFail = doc.CreateElement("wsdl", varMessage, wsdlURI);
                messageFail.SetAttribute("name", string.Format("{0}Fallo", item.Name));

                wsdlPart = doc.CreateElement("wsdl", "part", wsdlURI);
                wsdlPart.SetAttribute("name", string.Format("{0}Fallo", item.Name));
                wsdlPart.SetAttribute("element", string.Format("tns:{0}Fallo", item.Name));

                messageFail.AppendChild(wsdlPart);

                definitions.AppendChild(messageFail);
            }
        }

        private void CreatePortTypeSection(string fullServiceName, XmlDocument doc, string wsdlURI, XmlElement definitions)
        {
            XmlElement portType = doc.CreateElement("wsdl", "portType", wsdlURI);
            portType.SetAttribute("name", fullServiceName);

            XmlElement wsdlOperation, wsdlInput, wsdlOutput, wsdlFault, documentation;

            //Mensajes
            foreach (var item in this.methods)
            {
                wsdlOperation = doc.CreateElement("wsdl", "operation", wsdlURI);
                wsdlOperation.SetAttribute("name", item.Name);

                documentation = doc.CreateElement("wsdl", "documentation", wsdlURI);
                documentation.InnerText = item.Documentation;
                wsdlOperation.AppendChild(documentation);

                wsdlInput = doc.CreateElement("wsdl", "input", wsdlURI);
                wsdlInput.SetAttribute("name", item.Name);
                wsdlInput.SetAttribute("message", string.Format("tns:{0}", item.Name));
                wsdlOperation.AppendChild(wsdlInput);

                wsdlOutput = doc.CreateElement("wsdl", "output", wsdlURI);
                wsdlOutput.SetAttribute("name", String.Format("{0}Resp", item.Name));
                wsdlOutput.SetAttribute("message", string.Format("tns:{0}Resp", item.Name));
                wsdlOperation.AppendChild(wsdlOutput);

                wsdlFault = doc.CreateElement("wsdl", "fault", wsdlURI);
                wsdlFault.SetAttribute("name", String.Format("{0}Fallo", item.Name));
                wsdlFault.SetAttribute("message", string.Format("tns:{0}Fallo", item.Name));
                wsdlFault.InnerText = "";
                wsdlOperation.AppendChild(wsdlFault);

                portType.AppendChild(wsdlOperation);
            }

            definitions.AppendChild(portType);
        }

        private void CreateBindingSection(string fullServiceName, string targetNamespace, XmlDocument doc, string wsdlURI, XmlElement definitions, string soapURI)
        {
            string soapVersion = "";

            XmlElement binding = doc.CreateElement("wsdl", "binding", wsdlURI);

            if (this.type == ServiceType.Application)
            {
                soapVersion = "soap12";
                binding.SetAttribute("name", string.Format("bnd{0}SOAP12", fullServiceName));
            }   
            else
            {
                soapVersion = "soap";
                binding.SetAttribute("name", string.Format("bnd{0}SOAP", fullServiceName));
            }

            binding.SetAttribute("type", string.Format("tns:{0}", fullServiceName));


            XmlElement soapBinding = doc.CreateElement(soapVersion, "binding", soapURI);

            soapBinding.SetAttribute("style", "document");            

            soapBinding.SetAttribute("transport", "http://schemas.xmlsoap.org/soap/http");

            binding.AppendChild(soapBinding);

            XmlElement wsdlOperation;
            XmlElement soapOperation;
            XmlElement wsdlInput;
            XmlElement wsdlOutput;
            XmlElement wsdlFault;
            XmlElement soapBody;
            XmlElement soapFault;

            //Mensajes
            foreach (var item in this.methods)
            {
                wsdlOperation = doc.CreateElement("wsdl", "operation", wsdlURI);
                wsdlOperation.SetAttribute("name", item.Name);

                soapOperation = doc.CreateElement(soapVersion, "operation", soapURI);

                soapOperation.SetAttribute("soapAction", string.Format("{0}{1}", targetNamespace, item.Name));

                wsdlOperation.AppendChild(soapOperation);

                soapBody = doc.CreateElement(soapVersion, "body", soapURI);
                soapBody.SetAttribute("use", "literal");

                wsdlInput = doc.CreateElement("wsdl", "input", wsdlURI);
                wsdlInput.AppendChild(soapBody);

                wsdlInput.SetAttribute("name", item.Name);

                soapBody = doc.CreateElement(soapVersion, "body", soapURI);
                soapBody.SetAttribute("use", "literal");

                wsdlOutput = doc.CreateElement("wsdl", "output", wsdlURI);

                wsdlOutput.SetAttribute("name", String.Format("{0}Resp", item.Name));

                wsdlOutput.AppendChild(soapBody);

                wsdlFault = doc.CreateElement("wsdl", "fault", wsdlURI);
                wsdlFault.SetAttribute("name", String.Format("{0}Fallo", item.Name));

                soapFault = doc.CreateElement(soapVersion, "fault", soapURI);
                soapFault.SetAttribute("use", "literal");
                soapFault.SetAttribute("name", String.Format("{0}Fallo", item.Name));

                wsdlFault.AppendChild(soapFault);

                wsdlOperation.AppendChild(wsdlInput);
                wsdlOperation.AppendChild(wsdlOutput);
                wsdlOperation.AppendChild(wsdlFault);

                binding.AppendChild(wsdlOperation);
            }

            definitions.AppendChild(binding);
        }

        private void CreateServiceSection(string fullServiceName, string targetNamespace, XmlDocument doc, string wsdlURI, string soapURI, XmlElement definitions)
        {
            XmlElement service = doc.CreateElement("wsdl", "service", wsdlURI);
            service.SetAttribute("name", fullServiceName);

            XmlElement wsdlPort = doc.CreateElement("wsdl", "port", wsdlURI);


            XmlElement address = null;

            if(this.type == ServiceType.Application)
            {
                address = doc.CreateElement("soap12", "address", soapURI);
                wsdlPort.SetAttribute("binding", string.Format("tns:bnd{0}SOAP12", fullServiceName));
                wsdlPort.SetAttribute("name", string.Format("{0}SOAP12", fullServiceName));
            }
            else
            {
                address = doc.CreateElement("soap", "address", soapURI);
                wsdlPort.SetAttribute("binding", string.Format("tns:bnd{0}SOAP", fullServiceName));
                wsdlPort.SetAttribute("name", string.Format("{0}SOAP", fullServiceName));
            }

            address.SetAttribute("location", targetNamespace);

            wsdlPort.AppendChild(address);

            service.AppendChild(wsdlPort);
            definitions.AppendChild(service);

            doc.AppendChild(definitions);
        }
        
        private string GetServicePrefix()
        {
            string pref = "";

            switch (type)
            {
                case ServiceType.Entity:
                    pref = ConfigurationManager.AppSettings["SERVICE_PREF_INT"];
                    break;

                case ServiceType.Process:
                    pref = ConfigurationManager.AppSettings["SERVICE_PREF_PROCESS"];
                    break;

                case ServiceType.Task:
                    pref = ConfigurationManager.AppSettings["SERVICE_PREF_TAR"];
                    break;
                case ServiceType.Application:
                    pref = ConfigurationManager.AppSettings["SERVICE_PREF_APP"];
                    break;

                default:
                    pref = "";
                    break;
            }

            return pref;
        }

        public Capacity getCapacity(string name)
        {
            Capacity capacity = null;

            foreach (var item in this.methods)
            {
                if (item.Name.ToUpper().Equals(name.ToUpper()))
                {
                    capacity = item;
                    break;
                }
            }

            return capacity;
        }

        public void DeleteCapacity(string name)
        {
            this.Methods.Remove(this.getCapacity(name));
        }

        public BussinessObject getBO(string name)
        {
            BussinessObject bo = null;

            foreach (var item in this.BussinesObjects)
            {
                if (item.Name.ToUpper().Equals(name.ToUpper()))
                {
                    bo = item;
                    break;
                }
            }

            return bo;
        }
        public void DeleteBO(string name)
        {
            this.BussinesObjects.Remove(this.getBO(name));
        }

        public void SaveMetadata()
        {
            #region File Creation

            string directoryPath = String.Format(@"{0}\{1}{2}\", this.wsdlsPath, this.servicePref, this.ServiceName);
            string xmlPath = string.Format(@"{0}\MD-{1}{2}.xml", directoryPath, this.servicePref, this.ServiceName);

            if (System.IO.File.Exists(xmlPath))
            {
                System.IO.File.Delete(xmlPath);
            }

            #endregion

            XmlDocument doc = new XmlDocument();
            XmlNode docNode = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            doc.AppendChild(docNode);

            XmlElement service = doc.CreateElement("service");

            service.SetAttribute("name", this.ServiceName);
            service.SetAttribute("domain", this.Domain);
            service.SetAttribute("type", this.Type.ToString());

            doc.AppendChild(service);

            XmlElement description = doc.CreateElement("description");
            description.InnerText = this.Documentation;
            service.AppendChild(description);

            XmlElement methods = doc.CreateElement("methods");
            service.AppendChild(methods);

            XmlElement method = null;
            XmlElement parametersIn = null;
            XmlElement parameterIn = null;
            XmlElement parametersOut = null;
            XmlElement parameterOut = null;

            foreach (var item in this.Methods)
            {
                method = doc.CreateElement("method");
                method.SetAttribute("name", item.Name);
                method.SetAttribute("description", item.Documentation);

                parametersIn = doc.CreateElement("parametersIn");
                method.AppendChild(parametersIn);

                foreach (var parIn in item.ParametersIn)
                {
                    parameterIn = doc.CreateElement("parameterIn");
                    parameterIn.SetAttribute("type", parIn.Type);
                    parameterIn.SetAttribute("name", parIn.Name);
                    parameterIn.SetAttribute("minOccurs", parIn.MinOccurs);
                    parameterIn.SetAttribute("maxOccurs", parIn.MaxOccurs);

                    if (parIn.Obj != null)
                        parameterIn.SetAttribute("obj", parIn.Obj.Name);

                    parameterIn.SetAttribute("container", parIn.Container);
                    parameterIn.SetAttribute("listName", parIn.ListName);

                    parametersIn.AppendChild(parameterIn);
                }


                parametersOut = doc.CreateElement("parametersOut");
                method.AppendChild(parametersOut);

                foreach (var parOut in item.ParametersOut)
                {
                    parameterOut = doc.CreateElement("parameterOut");
                    parameterOut.SetAttribute("type", parOut.Type);
                    parameterOut.SetAttribute("name", parOut.Name);
                    parameterOut.SetAttribute("minOccurs", parOut.MinOccurs);
                    parameterOut.SetAttribute("maxOccurs", parOut.MaxOccurs);

                    if (parOut.Obj != null)
                        parameterOut.SetAttribute("obj", parOut.Obj.Name);

                    parameterOut.SetAttribute("container", parOut.Container);
                    parameterOut.SetAttribute("listName", parOut.ListName);

                    parametersOut.AppendChild(parameterOut);
                }

                methods.AppendChild(method);

            }


            XmlElement schemas = doc.CreateElement("schemas");
            service.AppendChild(schemas);


            XmlElement schema = null;

            foreach (var item in this.BussinesObjects)
            {
                schema = doc.CreateElement("schema");

                schema.SetAttribute("name", item.Name);
                schema.SetAttribute("path", item.Path);
                schema.SetAttribute("namespace", item.NameSpace);
                schema.SetAttribute("domain", item.Domain);
                schema.SetAttribute("isExtern", item.IsExtern.ToString());

                schemas.AppendChild(schema);
            }

            doc.Save(xmlPath);       

        }

        public void SaveWSRRFile()
        {
            #region File Creation

            string directoryPath = string.Format(@"{0}\{1}{2}\", this.wsdlsPath, this.servicePref, this.ServiceName);
            string xmlPath = string.Format(@"{0}\{1}{2}.xml", directoryPath, this.servicePref, this.ServiceName);

            if (System.IO.File.Exists(xmlPath))
            {
                System.IO.File.Delete(xmlPath);
            }

            #endregion

            XmlDocument doc = new XmlDocument();
            XmlNode docNode = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            doc.AppendChild(docNode);

            XmlElement configuracionServicio = doc.CreateElement("ConfiguracionServicio");

            doc.AppendChild(configuracionServicio);

            XmlElement ideServicio = doc.CreateElement("ideServicio");
            ideServicio.InnerText = string.Format(@"{0}{1}", this.servicePref, this.ServiceName);


            configuracionServicio.AppendChild(ideServicio);

            XmlElement operaciones = doc.CreateElement("operaciones");
            configuracionServicio.AppendChild(operaciones);


            XmlElement method = null;

            foreach (var item in this.Methods)
            {
                method = doc.CreateElement(item.Name);

                XmlElement auditable = doc.CreateElement("auditable");
                auditable.InnerText = "1";

                XmlElement tiempoRespuestaExpiracion = doc.CreateElement("tiempoRespuestaExpiracion");
                tiempoRespuestaExpiracion.InnerText = "3000";

                XmlElement activo = doc.CreateElement("activo");
                activo.InnerText = "1";


                method.AppendChild(auditable);
                method.AppendChild(tiempoRespuestaExpiracion);
                method.AppendChild(activo);

                operaciones.AppendChild(method);

            }

            doc.Save(xmlPath);

        }

        private T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }

        public void LoadWSDL(XmlDocument doc)
        {
            XmlNodeList nodes = doc.GetElementsByTagName("service");

            if (nodes.Count > 0)
            {

                this.serviceName = nodes[0].Attributes.GetNamedItem("name").Value;
                this.Type = this.ParseEnum<ServiceType>(nodes[0].Attributes.GetNamedItem("type").Value);
                this.Domain = nodes[0].Attributes.GetNamedItem("domain").Value;
                this.Documentation = nodes[0].ChildNodes[0].InnerText;
                
                XmlNode schemas = nodes[0].ChildNodes[2];
                BussinessObject bo = null;

                foreach (XmlNode item in schemas.ChildNodes)
                {
                    bo = new BussinessObject();

                    bo.Name = item.Attributes.GetNamedItem("name").Value;
                    bo.Path = item.Attributes.GetNamedItem("path").Value;
                    bo.NameSpace = item.Attributes.GetNamedItem("namespace").Value;

                    if (item.Attributes.GetNamedItem("domain") != null)
                    {
                        bo.Domain = item.Attributes.GetNamedItem("domain").Value;
                    }

                    if (item.Attributes.GetNamedItem("isExtern") != null)
                    {
                        bo.IsExtern = Boolean.Parse(item.Attributes.GetNamedItem("isExtern").Value);
                    }

                    this.BussinesObjects.Add(bo);
                }

                XmlNode methods = nodes[0].ChildNodes[1];

                Capacity method;
                Parameter param = null;

                foreach (XmlNode item in methods.ChildNodes)
                {
                    method = new Capacity();

                    method.Name = item.Attributes.GetNamedItem("name").Value;
                    method.Documentation = item.Attributes.GetNamedItem("description").Value;

                    if (item.ChildNodes[0] != null)
                    {
                        foreach (XmlNode parameter in item.ChildNodes[0].ChildNodes)
                        {
                            param = ConfigParameter(parameter);
                            method.ParametersIn.Add(param);
                        }
                    }

                    if (item.ChildNodes[1] != null)
                    {
                        foreach (XmlNode parameter in item.ChildNodes[1].ChildNodes)
                        {
                            param = ConfigParameter(parameter);
                            method.ParametersOut.Add(param);
                        }

                        
                    }

                    this.methods.Add(method);
                }
            }
            else
            {
                throw new Exception("Archivo no valido.");
            }
        }

        private Parameter ConfigParameter(XmlNode parameter)
        {
            Parameter param;
            param = new Parameter();

            if (parameter.Attributes.GetNamedItem("container") != null)
            {
                param.Container = parameter.Attributes.GetNamedItem("container").Value;
            }

            if (parameter.Attributes.GetNamedItem("listName") != null)
            {
                param.ListName = parameter.Attributes.GetNamedItem("listName").Value;
            }

            param.MinOccurs = parameter.Attributes.GetNamedItem("minOccurs").Value;
            param.Name = parameter.Attributes.GetNamedItem("name").Value;
            param.MaxOccurs = parameter.Attributes.GetNamedItem("maxOccurs").Value;


            if (parameter.Attributes.GetNamedItem("obj") != null)
            {
                param.Obj = this.getBO(parameter.Attributes.GetNamedItem("obj").Value);
            }
            else
            {
                param.Type = parameter.Attributes.GetNamedItem("type").Value;
            }
            return param;
        }
        
        #endregion
    }
}