using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoGenClass.Common
{
    public class Property
    {
        public string AccessModifier { get; set; }
        public string DataType { get; set; }
        public string Name { get; set; }

        override public string ToString()
        {
            return AccessModifier + " " + DataType + " " + Name + ";\n";
        }
    }
}
