namespace Day_25_CRUD_Operations_with_Repository_Pattern.Wrapper
{
    public class ProductResponse<T>
    {
        public bool Success { get; set; }
        public T? Data { get; set; }
        public string Message { get; set; }
        public List<string>? Errors { get; set; }

        public ProductResponse(T Data, string Message)
        {
            Success = true;
            this.Data = Data;
            this.Message = Message;
            Errors = null;
        }

        public ProductResponse(string Message, List<string> Errors = null)
        {
            Success = false;
            Data = default(T);
            this.Message = Message;
            this.Errors = Errors; 
        }
    }
}
