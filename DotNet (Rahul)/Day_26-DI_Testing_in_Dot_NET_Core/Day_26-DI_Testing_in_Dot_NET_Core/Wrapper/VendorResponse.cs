namespace Day_26_DI_Testing_in_Dot_NET_Core.Wrapper
{
    public class VendorResponse<T>
    {
        public bool Success { get; set; }
        public T? Data { get; set; }
        public string Message { get; set; }
        public List<string>? Errors { get; set; }

        public VendorResponse(T? data, string message)
        {
            Success = true;
            this.Data = data;
            this.Message = message;
            Errors = null;
        }

        public VendorResponse(string Message, List<string> Errors = null)
        {
            Success = false;
            Data = default(T);
            this.Message = Message;
            this.Errors = Errors;
        }
    }
}
