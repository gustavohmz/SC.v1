
namespace SC.v1.Common.Common.PaginationConfiguration
{

    public class PaginationParams
    {
       
        public int limit { get; set; } = 50;
       
        public int offset { get; set; } = 0;
       
        public string? sort { get; set; }

        public string? direction { get; set; } = "asc";

    }
}
