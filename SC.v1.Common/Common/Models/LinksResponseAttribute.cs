using SC.v1.Common.Common.PaginationConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC.v1.Common.Common.Models
{
    public class LinksResponseAttribute
    {
        public Pagination pagination { get; set; }

        public LinksResponseAttribute()
        { 
            pagination=new Pagination();
        }
    }
}
