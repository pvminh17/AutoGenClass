using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AutoGenClass.Extractor
{
    public class OracelExtractorImpl : IExtractor
    {
        public List<DatabaseColumn> ExtractFromDLL(string input)
        {
            string primaryKey = string.Empty;
            string temp = removeNoise(input,ref primaryKey);
            temp = findListColumn(temp);
            var lstColumn = selectColumnAndDataType(temp);
            lstColumn.ForEach(obj =>
            {
                obj.IsPrimaryKey = obj.Name.Trim() == primaryKey.Trim();
            });
            return lstColumn;
        }

        private string removeNoise(string strDDL, ref string primaryKey)
        {
            primaryKey = Regex.Match(strDDL, "\\(\\\"[A-Za-z]+\\\"\\)").Value.Trim('(',')').Trim('"');
            string result = string.Empty;
            result = Regex.Replace(strDDL, "[(][123456789][0123456789][\\,][0][)]", "_long"); //số thập phân -> NUMBER_long
            result = Regex.Replace(result, "[(][\\d]+[\\,][123456789]+[)]", "_double"); //số thập phân -> NUMBER_double or FLOAT_double
            result = Regex.Replace(result, "[(][\\d]+[\\,][\\d]+[)]", ""); // số nguyên -> NUMBER or FLOAT
            result = Regex.Replace(result, "[(][\\d]+[)]", "");
            result = result.Replace(System.Environment.NewLine, "");
            result = result.Replace("\"", "");
            result = result.Replace("\n", "");
            result = result.Replace("\t", "");
            result = result.Replace(@"\s\s+", " ");

            return result;
        }

        private string removeNoise(string strDDL)
        {
            string _ = string.Empty;
            return removeNoise(strDDL, ref _);
        }

        private string findListColumn(string strDDL)
        {
            Stack<char> stack = new Stack<char>();
            int posStart = -1;
            int posEnd = -1;

            for (int i = 0; i < strDDL.Length; i++)
            {
                if (strDDL[i] == '(')
                {
                    if (posStart < 0)
                        posStart = i;
                    stack.Push(strDDL[i]);
                }

                if (strDDL[i] == ')')
                {
                    stack.Pop();
                    if (stack.Count == 0)
                    {
                        posEnd = i;
                        break;
                    }
                }
            }

            string result = strDDL.Substring(posStart + 1, posEnd - posStart - 1);
            return result;
        }

        private List<DatabaseColumn> selectColumnAndDataType(string strDDL)
        {

            List<DatabaseColumn> columns = new List<DatabaseColumn>();

            string[] arrColumn = strDDL.Split(',');

            foreach (string col in arrColumn)
            {
                string[] value = col.Trim().Split(' ');
                if (value[0].Trim() != "CONSTRAINT" && value[0].Trim() != "PRIMARY")
                {
                    columns.Add(new DatabaseColumn
                    {
                        Name = value[0].Trim(),
                        DataType = value[1].Trim(),
                    });
                }
            }
            return columns;
        }

        public string GetTableName(string input)
        {
            string temp = removeNoise(input);
            string createTable = "CREATE TABLE ";
            int beginPos = temp.IndexOf(createTable) + createTable.Length;
            int endPos = temp.IndexOf("(");
            string nameAndSchema = temp.Substring(beginPos, endPos - beginPos).Trim();
            string tableName = nameAndSchema.Split('.')[1];
            return tableName;

        }

        public DatabaseTable GetMetadata(string input)
        {
            DatabaseTable table = new DatabaseTable();

            //Trich du lieu
            string temp = removeNoise(input);
            string createTable = "CREATE TABLE ";
            int beginPos = temp.IndexOf(createTable) + createTable.Length;
            int endPos = temp.IndexOf("(");
            string nameAndSchema = temp.Substring(beginPos, endPos - beginPos).Trim();

            table.Name = nameAndSchema.Split('.')[1];
            table.Schema = nameAndSchema.Split('.')[0];
            table.Columns = ExtractFromDLL(input);

            return table;

        }
    }
}
