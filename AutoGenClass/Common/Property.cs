using AutoGenClass.Converters;
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
        public bool IsPrimaryKey { get; set; }

        override public string ToString()
        {
            return AccessModifier + " " + DataType + " " + Name + ";\n";
        }

        public string ToGetter()
        {
            var sb = new StringBuilder();
            sb.Append("public ");
            sb.Append(DataType + " ");
            if (DataType != "boolean")
                sb.Append("get");
            else
                sb.Append("is");
            sb.Append(Utility.FirstCharToUpper(Name) + "() {");
            sb.Append("{\n");
            sb.Append("\t");
            sb.Append("return this." + Name + ";");
            sb.Append("}");
            return sb.ToString();
        }


    }
}
