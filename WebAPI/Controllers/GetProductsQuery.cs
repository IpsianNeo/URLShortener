using MediatR;

namespace WebAPI.Controllers
{
    internal class GetProductsQuery : IRequest<object?>
    {
        public GetProductsQuery(string? searchTerm, string? sortColumn, string? sortOrder, int page, int pageSize)
        {
            SearchTerm = searchTerm;
            SortColumn = sortColumn;
            SortOrder = sortOrder;
            Page = page;
            PageSize = pageSize;
        }

        public string? SearchTerm { get; }
        public string? SortColumn { get; }
        public string? SortOrder { get; }
        public int Page { get; }
        public int PageSize { get; }
    }
}