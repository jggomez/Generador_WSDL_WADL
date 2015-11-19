using CMI_WSDLCreator.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMI_WSDLCreator
{
    public enum ParametersType
    {
        IN,
        OUT
    }

    public class Parameter
    {
        private string name;
        private string type;
        private string minOccurs;
        private string maxOccurs;
        private BussinessObject obj;
        private string container;
        private string listName;

        public string ListName
        {
            get { return listName; }
            set { listName = value; }
        }

        public string Container
        {
            get { return container; }
            set { container = value; }
        }

        public BussinessObject Obj
        {
            get { return obj; }
            set { obj = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        
        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        
        public string MinOccurs
        {
            get { return minOccurs; }
            set { minOccurs = value; }
        }       

        public string MaxOccurs
        {
            get { return maxOccurs; }
            set { maxOccurs = value; }
        }
    }
}
