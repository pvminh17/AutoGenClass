using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoGenClass.Extractor
{
    public class DatabaseTable
    {
        public string Name { get; set; }
        public string Schema { get; set; }
        public List<DatabaseColumn> Columns { get; set; }
    }
}
