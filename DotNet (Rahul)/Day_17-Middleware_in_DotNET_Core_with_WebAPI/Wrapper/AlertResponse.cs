namespace Day_17_Middleware_in_DotNET_Core_with_WebAPI.Wrapper
{
    public class AlertResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T? Data { get; set; }
        public List<string>? Errors { get; set; }
        public AlertResponse(T Data, string Message)
        {
            Success = true;
            this.Message = Message;
            this.Data = Data;
            Errors = null;
        }
        public AlertResponse(string Message, List<string>? Errrors = null)
        {
            Success = false;    
            this.Message = Message;
            Data = default(T);
            this.Errors = Errrors;
        }
    }
}