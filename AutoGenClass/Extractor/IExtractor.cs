using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoGenClass.Extractor
{
    public interface IExtractor
    {
        List<DatabaseColumn> ExtractFromDLL(string input); 
    }
}
