using AutoGenClass.Common;
using AutoGenClass.Extractor;
using System;
using System.Collections.Generic;
using System.IO;
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
            dicDBTypeToJavaType["NUMBER_long"] = "long";
            dicDBTypeToJavaType["NUMBER_double"] = "double";
            dicDBTypeToJavaType["FLOAT_double"] = "double";
            dicDBTypeToJavaType["FLOAT"] = "float";
            dicDBTypeToJavaType["REAL"] = "float";
            dicDBTypeToJavaType["SMALLINT"] = "int";
            dicDBTypeToJavaType["TIMESTAMP"] = "java.sql.Date";
            dicDBTypeToJavaType["DATE"] = "java.sql.Date";
            dicDBTypeToJavaType["BOOLEAN"] = "boolean";
            dicDBTypeToJavaType["NVARCHAR2"] = "String";
            dicDBTypeToJavaType["VARCHAR2"] = "String";
            dicDBTypeToJavaType["VARCHAR"] = "String";
            dicDBTypeToJavaType["NVARCHAR"] = "String";
            dicDBTypeToJavaType["CHAR"] = "String";
        }

        public string Process(string input, string entityCustomname = "")
        {
            string tableName = oracelExtractor.GetTableName(input);
            var arrStr = tableName.Split('_');
            tableName = String.Empty;
            for (int i = 1; i < arrStr.Length; i++)
            {
                tableName += arrStr[i];
            }
            tableName = Utility.FirstCharToUpper(dictionaryWord.ToCamel(tableName));
            if (!string.IsNullOrEmpty(entityCustomname)) tableName = entityCustomname;


            var lstColumn = oracelExtractor.ExtractFromDLL(input);

            string resut = "public class " + tableName + "Entity{\n";

            foreach (var column in lstColumn)
            {
                if (column.Name.Contains("CDC")) continue;

                resut += "    private ";

                //if (column.Name.IndexOf("IS") == 0)
                //{
                //    resut += "boolean ";
                //}
                //else
                if (dicDBTypeToJavaType.ContainsKey(column.DataType))
                    resut += dicDBTypeToJavaType[column.DataType] + " ";
                else
                {
                    resut += "Object ";
                }
                resut += dictionaryWord.ToCamel(column.Name) + "; \n";
                //resut += column.Name + "; \n";
            }

            resut += "    private long totalRow; \n";

            resut += "}";
            return resut;
        }

        public Entity GenarateEntity(string input, string entityCustomname = "")
        {
            Entity entity = new Entity();
            entity.Properties = new List<Property>();
            string tableName = oracelExtractor.GetTableName(input);
            var arrStr = tableName.Split('_');
            tableName = String.Empty;
            for (int i = 1; i < arrStr.Length; i++)
            {
                tableName += arrStr[i];
            }
            entity.Name = Utility.FirstCharToUpper(dictionaryWord.ToCamel(tableName));
            if (!string.IsNullOrEmpty(entityCustomname)) entity.Name = entityCustomname;


            var lstColumn = oracelExtractor.ExtractFromDLL(input);

            foreach (var column in lstColumn)
            {

                if (column.Name.Contains("CDC")) continue;
                Property property = new Property();
                property.AccessModifier = "private";

                //if (column.Name.IndexOf("IS") == 0)
                //{
                //    property.DataType = "boolean";
                //}
                //else
                if (dicDBTypeToJavaType.ContainsKey(column.DataType))
                {
                    property.DataType = dicDBTypeToJavaType[column.DataType];
                }
                else
                {
                    property.DataType = "Object";
                }
                property.IsPrimaryKey = column.IsPrimaryKey;
                property.Name = dictionaryWord.ToCamel(column.Name);
                entity.Properties.Add(property);
            }
            entity.Properties.Add(new Property()
            {
                AccessModifier = "private",
                DataType = "long",
                IsPrimaryKey = false,
                Name = "totalRow"
            });
            return entity;
        }

        public string ToIDAO(string input, string entityCustomname = "")
        {
            string strTemplate = File.ReadAllText("JavaTemplate/IDAO.tp", Encoding.UTF8);
            var entity = GenarateEntity(input);
            if (!string.IsNullOrEmpty(entityCustomname)) entity.Name = entityCustomname;

            strTemplate = strTemplate.Replace("{{EntityName}}", entity.Name);

            var primaryKey = entity.Properties.Where(obj => obj.IsPrimaryKey).First();
            strTemplate = strTemplate.Replace("{{PRIMARY_KEY_DATA_TYPE}}", primaryKey.DataType);
            strTemplate = strTemplate.Replace("{{PRIMARY_KEY}}", primaryKey.Name);

            return strTemplate;
        }

        public string ToDAOImpl(string input, string entityCustomname = "")
        {
            var table = oracelExtractor.GetMetadata(input);
            var entity = GenarateEntity(input);
            if (!string.IsNullOrEmpty(entityCustomname)) entity.Name = entityCustomname;
            var primaryKey = entity.Properties.Where(obj => obj.IsPrimaryKey).First();

            string strTemplate = File.ReadAllText("JavaTemplate/DAOImpl.tp", Encoding.UTF8);
            //The ten entity
            strTemplate = strTemplate.Replace("{{EntityName}}", entity.Name);

            //search
            string storeSrh = table.Schema + "." + table.Name + "_SRH";
            strTemplate = strTemplate.Replace("{{STORE_SRH}}", storeSrh);

            //insert
            string lstInsertParam = "";
            int count = 0;
            var lstExcludeIns = new List<string>() { "USERDELETE", "DATEDELETE", "ISDELETE"
                                                , "CREATEDDATE", "UPDATEDUSER", "UPDATEDDATE"
                                                ,"ISDELETED","DELETEDUSER","DELETEDDATE", "INPUTTIME", primaryKey.Name};
            for (int i = 0; i < entity.Properties.Count; i++)
            {
                if (lstExcludeIns.Any(str => str.ToLower().Equals(entity.Properties[i].Name.ToLower()))) continue;
                count++;
                lstInsertParam += string.Format("\t\t\tpStmt.setObject({0}, entity.get{1}());\n",
                                    count + 1,
                                    Utility.FirstCharToUpper(entity.Properties[i].Name));

            }
            strTemplate = strTemplate.Replace("{{LST_INSERT_PRO}}", lstInsertParam);

            string storeIns = table.Schema + "." + table.Name + "_ADD";
            storeIns += "(" + string.Join(",", Enumerable.Repeat("?", count)) + ")";
            strTemplate = strTemplate.Replace("{{STORE_INS_STM}}", storeIns);

            //update
            string lstUpdateParam = "";
            var lstExcludeUpd = new List<string>() { "USERDELETE", "DATEDELETE", "ISDELETE"
                                                , "CREATEDDATE", "UPDATEDDATE"
                                                ,"ISDELETED","DELETEDUSER","DELETEDDATE", "INPUTTIME", "CREATEDUSER",primaryKey.Name};
            count = 0;
            for (int i = 0; i < entity.Properties.Count; i++)
            {
                if (lstExcludeUpd.Any(str => str.ToLower().Equals(entity.Properties[i].Name.ToLower()))) continue;
                count++;
                lstUpdateParam += string.Format("\t\t\tpStmt.setObject({0}, entity.get{1}());\n",
                                    count,
                                    Utility.FirstCharToUpper(entity.Properties[i].Name));

            }

            string storeUpd = table.Schema + "." + table.Name + "_UPD";
            storeUpd += "(" + string.Join(",", Enumerable.Repeat("?", count)) + ")";
            strTemplate = strTemplate.Replace("{{STORE_UPD_STM}}", storeUpd);
            strTemplate = strTemplate.Replace("{{LST_UPDATE_PRO}}", lstUpdateParam);

            //delete
            string storeDel = table.Schema + "." + table.Name + "_DEL";
            strTemplate = strTemplate.Replace("{{STORE_DEL}}", storeDel);

            strTemplate = strTemplate.Replace("{{PRIMARY_KEY_DATA_TYPE}}", primaryKey.DataType);
            strTemplate = strTemplate.Replace("{{PRIMARY_KEY}}", primaryKey.Name);

            //load info
            string storeSel = table.Schema + "." + table.Name + "_SEL";
            strTemplate = strTemplate.Replace("{{STORE_SEL}}", storeSel);
            return strTemplate;
        }

        public string ToIService(string input, string entityCustomname = "")
        {
            string strTemplate = File.ReadAllText("JavaTemplate/IService.tp", Encoding.UTF8);
            var entity = GenarateEntity(input);
            if (!string.IsNullOrEmpty(entityCustomname)) entity.Name = entityCustomname;

            return strTemplate.Replace("{{EntityName}}", entity.Name);
        }

        public string ToRequest(string input, string entityCustomname = "")
        {
            string strTemplate = File.ReadAllText("JavaTemplate/Request.tp", Encoding.UTF8);
            var entity = GenarateEntity(input);
            if (!string.IsNullOrEmpty(entityCustomname)) entity.Name = entityCustomname;

            return strTemplate.Replace("{{EntityName}}", entity.Name);
        }

        public string ToServiceImpl(string input, string entityCustomname = "")
        {
            string strTemplate = File.ReadAllText("JavaTemplate/ServiceImpl.tp", Encoding.UTF8);

            var entity = GenarateEntity(input);
            if (!string.IsNullOrEmpty(entityCustomname)) entity.Name = entityCustomname;

            strTemplate = strTemplate.Replace("{{EntityName}}", entity.Name);
            strTemplate = strTemplate.Replace("{{EntityNameVar}}", Utility.FirstCharToLower(entity.Name));
            return strTemplate;
        }

        public string ToResponse(string input, string entityCustomname = "")
        {
            string strTemplate = File.ReadAllText("JavaTemplate/Response.tp", Encoding.UTF8);
            var entity = GenarateEntity(input);
            if (!string.IsNullOrEmpty(entityCustomname)) entity.Name = entityCustomname;
            return strTemplate.Replace("{{EntityName}}", entity.Name);
        }
    }
}
