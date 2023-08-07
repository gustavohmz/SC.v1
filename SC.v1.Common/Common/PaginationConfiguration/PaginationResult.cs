using SC.v1.Common.Common.Models;

namespace SC.v1.Common.Common.PaginationConfiguration
{
    public static class PaginationResult
    {
        public static Pagination SetPaginationResult(int count, int pageNumber, int pageSize)
        {
            var pagination_response = new Pagination();

            pagination_response.first = 0;
            pagination_response.last = (int)Math.Ceiling(count / (double)pageSize);
            pagination_response.prev = pageNumber > 0 ? pageNumber - 1 : 0;
            pagination_response.next = pageNumber + 1;
            pagination_response.current = pageNumber;
            pagination_response.size = pageSize;

            return pagination_response;
        }
    }
}
