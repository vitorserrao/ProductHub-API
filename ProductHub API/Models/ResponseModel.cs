namespace ProductHub_API.Models
{
    public class ResponseModel<T>
    {
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }
        public bool Status { get; set; } = true;
    }
}
