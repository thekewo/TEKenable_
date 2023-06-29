public class JsonResultBase : IJsonResult
{
    public bool Success { get; set; }
    public string Message { get; set; }
}