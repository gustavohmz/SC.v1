using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC.v1.Common.Common.PaginationConfiguration
{
    public class Pagination
    {
        public int first { get; set; }
        public int last { get; set; }
        public int prev { get; set; }
        public int next { get; set; }
        public int current { get; set; }
        public int size { get; set; }
    }
}
