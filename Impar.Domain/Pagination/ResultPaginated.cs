namespace Impar.Domain.Pagination;
public class ResultPaginated<T>
{
    public ResultPaginated()
    {
        Itens = new List<T>();
        Pagination = new Pagination();
    }

    public ResultPaginated(int page, int pageSize, int total, List<T> itens) : this()
    {
        Itens = itens;
        Pagination = new Pagination
        {
            TotalInPage = itens.Count,
            Page = page,
            PageSize = pageSize,
            Total = total
        };
    }

    public IList<T> Itens
    { get; set; }
    public Pagination Pagination { get; set; }
}
