public interface IJsonResult
{
    bool Success { get; set; }
    string Message { get; set; }
}

public interface IListJsonResult : IJsonResult
{
    int Count { get; set; }
}