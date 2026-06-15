using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Day_18_Authentication_and_Authorization_in_Web_APIs.Wrapper
{
    public class CodeReviewResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T? Data { get; set; }
        public List<string>? Erorrs { get; set; }
        public CodeReviewResponse(T Data, string Message)
        {
            Success = true;
            this.Data = Data;
            this.Message = Message;
            Erorrs = null;
        }
        public CodeReviewResponse(string Message, List<string>? Erorrs = null)
        {
            Success = false;
            Data = default(T);
            this.Message = Message;
            this.Erorrs = Erorrs;
        }
    }
}
