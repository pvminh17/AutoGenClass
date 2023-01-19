using AutoGenClass.Extractor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AutoGenClass.Converters
{
    public class DDLtoJavaClass
    {
        private Dictionary<string, string> dicDBTypeToJavaType = new Dictionary<string, string>();
        private OracelExtractorImpl oracelExtractor = new OracelExtractorImpl();
        private DictionaryWord dictionaryWord = new DictionaryWord("dicWord.txt", false);

        public DDLtoJavaClass()
        {
            genDicDBTypeToJavaType();
        }

        private void genDicDBTypeToJavaType()
        {
            dicDBTypeToJavaType["NUMBER"] = "int";
            dicDBTypeToJavaType["NUMBER_double"] = "double";
            dicDBTypeToJavaType["FLOAT_double"] = "double";
            dicDBTypeToJavaType["FLOAT"] = "float";
            dicDBTypeToJavaType["REAL"] = "float";
            dicDBTypeToJavaType["SMALLINT"] = "int";
            dicDBTypeToJavaType["TIMESTAMP"] = "Date";
            dicDBTypeToJavaType["DATE"] = "Date";
            dicDBTypeToJavaType["BOOLEAN"] = "boolean";
            dicDBTypeToJavaType["NVARCHAR2"] = "String";
            dicDBTypeToJavaType["VARCHAR2"] = "String";
            dicDBTypeToJavaType["VARCHAR"] = "String";
            dicDBTypeToJavaType["NVARCHAR"] = "String";
            dicDBTypeToJavaType["CHAR"] = "String";
        }

        public string Process(string input)
        {
            string tableName = oracelExtractor.GetTableName(input);
            var lstColumn = oracelExtractor.ExtractFromDLL(input);

            string resut = "public class " + tableName + "{\n";

            foreach (var column in lstColumn)
            {
                if (column.Name.Contains("CDC")) continue;

                resut += "\tprivate ";

                if (column.Name.IndexOf("IS") == 0)
                {
                    resut += "boolean ";
                }

                else if (dicDBTypeToJavaType.ContainsKey(column.DataType))
                    resut += dicDBTypeToJavaType[column.DataType] + " ";
                else
                {
                    resut += "Object ";
                }
                resut += dictionaryWord.ToCamel(column.Name) + "; \n";
            }
            resut += "}";
            return resut;
        }

    }
}
