namespace Day_22_Implement_Login_functionality_with_WebAPI.Wrapper
{
    public class UserResponse<T>
    {
        public bool Success { get; set; }
        public T? Data { get; set; }
        public string Message { get; set; }
        public List<string>? Errors { get; set; }

        public UserResponse(T? data, string message)
        {
            Success = true;
            this.Data = data;
            this.Message = message;
            Errors = null;
        }

        public UserResponse(string Message, List<string> Errors = null)
        {
            Success = false;
            Data = default(T);
            this.Message = Message;
            this.Errors = Errors;
        }
    }
}
