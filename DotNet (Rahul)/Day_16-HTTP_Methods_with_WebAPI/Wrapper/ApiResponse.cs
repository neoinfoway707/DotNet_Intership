namespace Day_16_HTTP_Methods_with_WebAPI.Wrapper
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public List<string>? Errors { get; set; }
        public ApiResponse(T Data, string Message) {
            Success = true;
            this.Message = Message;
            this.Data = Data;
            Errors = null;
        }
        public ApiResponse(string Message,List<string>? Errrors=null) { 
            Success = false;
            this.Message = Message;
            Data = default(T);
            this.Errors = Errrors;
        }
    }

}
