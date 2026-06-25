namespace ProductManagement.Web.Wrappers
{
    public class ClientResponse<T>
    {
        public bool Success { get; set; }
        public T? Data { get; set; }
        public string Message { get; set; }
        public List<string>? Errors { get; set; }
        public ClientResponse()
        {
        }
        public ClientResponse(T Data, string Message)
        {
            Success = true;
            this.Data = Data;
            this.Message = Message;
            Errors = null;
        }
        public ClientResponse(string Message, List<string>? Errors = null)
        {
            Success = false;
            Data = Data;
            this.Message = Message;
            this.Errors = Errors;
        }
    }
}
