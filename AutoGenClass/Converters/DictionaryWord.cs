using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AutoGenClass.Converters
{
    public class DictionaryWord
    {
        private HashSet<string> hashWord = null;
        private string dicPath = string.Empty;
        private bool isGetNewest = false;

        public DictionaryWord(string dicPath, bool isGetNewest = false)
        {
            this.dicPath = dicPath.Trim();
            this.isGetNewest = isGetNewest;
            genDicWord();
        }

        private void genDicWord()
        {
            if (string.IsNullOrEmpty(dicPath)) throw new Exception("Dic Path iss empty");

            hashWord = new HashSet<string>();

            string[] lines = System.IO.File.ReadAllLines(dicPath);
            foreach (string line in lines)
            {
                if (line != null && !string.IsNullOrEmpty(line.Trim()))
                    hashWord.Add(line.ToLower());
            }
        }

        public string ToCamel(string input)
        {
            if (isGetNewest) genDicWord();

            string result = string.Empty;
            int leftChar = input.Length;
            while (leftChar > 0)
            {
                int curpos = input.Length - leftChar;
                string addword = string.Empty;
                for (int i = input.Length - leftChar; i < input.Length; i++)
                {
                    string temp = input.Substring(curpos, i + 1 - curpos).ToLower();
                    if (hashWord.Contains(temp))
                    {
                        addword = temp;
                    }
                }

                if (leftChar == input.Length)
                {
                    result += addword;
                }
                else
                {
                    result += Utility.FirstCharToUpper(addword);
                }

                leftChar -= addword.Length;
            }

            return result;
        }
    }
}
