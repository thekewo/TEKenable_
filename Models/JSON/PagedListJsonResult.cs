public class PagedListJsonResult<T> : JsonResultBase, IListJsonResult
{
    public IEnumerable<T> List { get; set; }
    public int Count { get; set; }
}