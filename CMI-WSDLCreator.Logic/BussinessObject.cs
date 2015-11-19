using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMI_WSDLCreator.Logic
{
    public class BussinessObject
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string NameSpace { get; set; }
        public string Prefix { get; set; }
        public bool IsExtern { get; set; }
        public string Domain { get; set; }
    }
}
