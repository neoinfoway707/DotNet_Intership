namespace Day_19_Working_with_EF_Core_in_WebAPI.Wrapper
{
    public class SmartContainerResponse<T>
    {
        public bool Success { get; set; }
        public T? Data { get; set; }
        public string Message { get; set; }
        public List<string>? Errors { get; set; }

        public SmartContainerResponse(T Data, string Message)
        {
            Success = true;
            this.Data = Data;
            this.Message = Message;
            Errors = null;
        }
        public SmartContainerResponse(string Message, List<string> Errrors = null)
        {
            Success = false;
            Data = default(T);
            this.Message = Message;
            this.Errors = Errors;
        }
    }
}
