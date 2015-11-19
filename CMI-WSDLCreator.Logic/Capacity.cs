using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMI_WSDLCreator.Logic
{
    public class Capacity
    {
        private string name;
        private List<Parameter> parametersIn;
        private List<Parameter> parametersOut;
        private string documentation;

        public string Documentation
        {
            get { return documentation; }
            set { documentation = value; }
        }
        

        public List<Parameter> ParametersOut
        {
            get { return parametersOut; }
            set { parametersOut = value; }
        }

        public List<Parameter> ParametersIn
        {
            get { return parametersIn; }
            set { parametersIn = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Capacity()
        {
            this.parametersIn = new List<Parameter>();
            this.parametersOut = new List<Parameter>();
        }

        public Parameter getParameter(string name, ParametersType type )
        {
            Parameter param = null;

            List<Parameter> paramList = null;

            if (type == ParametersType.IN)
            {
                paramList = this.parametersIn;
            }
            else 
            {
                paramList = this.parametersOut;
            }

            foreach (var item in paramList)
            {
                if (item.Name.ToUpper().Equals(name.ToUpper()))
                {
                    param = item;
                    break;
                }
            }

            return param;
        }

        public void DeleteParameter(string name, ParametersType type)
        {
            if(type == ParametersType.IN)
            {
                this.ParametersIn.Remove(this.getParameter(name, type));
            }
            else 
            {
                this.ParametersOut.Remove(this.getParameter(name, type));
            }
            
        }

    }
}
