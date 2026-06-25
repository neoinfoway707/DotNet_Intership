namespace ProductManagement.WebApi.Wrapper
{
    public class ProductResponse<T>
    {
        public bool Success { get; set; }
        public T? Data { get; set; }
        public string Message { get; set; }
        public List<string>? Errors { get; set; }
        
        public ProductResponse() { }
        public ProductResponse(T data, string message)
        {
            Success = true;
            this.Data = data;
            this.Message = message;
            Errors = null;
        }
        public ProductResponse(string message, List<string>? Errors = null)
        {
            Success = false;
            Data = default(T);
            this.Message = message;
            this.Errors = Errors;
        }
    }
}