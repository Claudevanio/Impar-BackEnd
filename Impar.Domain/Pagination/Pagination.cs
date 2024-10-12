

namespace Impar.Domain.Pagination;
public class Pagination
{
    public int Total { get; set; }
    public int TotalInPage { get; set; }
    public int Page { get; set; }
    public int PageSize { get; set; }
    public int TotalPages { get; set; }
}
