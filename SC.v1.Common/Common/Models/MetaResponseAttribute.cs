using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC.v1.Common.Common.Models
{
    public class MetaResponseAttribute
    {
        public string copyright { get; set; }
        public string api_name { get; set; }
        public string api_version { get; set; }
        public DateTime timestamp { get; set; }

        public  MetaResponseAttribute()
        {
            copyright = "Sistema_Contable";
            api_name = "SC";
            api_version = "1.0";
            timestamp = DateTime.Now;
        }
    }   
}
