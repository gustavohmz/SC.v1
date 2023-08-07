using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC.v1.Common.Common.PaginationConfiguration
{
    public static class PaginationExtension
    {
        public static IQueryable<T> Pagingxxx<T>(this IQueryable<T> elements, int? page, int? pageSize)
        {
            if (page.HasValue && pageSize.HasValue)
                return elements.Skip(page.Value * pageSize.Value).Take(pageSize.Value);
            else
                return elements;
        }
    }
}
