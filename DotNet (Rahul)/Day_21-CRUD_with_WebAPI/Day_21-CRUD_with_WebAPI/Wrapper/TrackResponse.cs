namespace Day_21_CRUD_with_WebAPI.Wrapper
{
    public class TrackResponse<T>
    {
        public bool Success { get; set; }
        public T? Data { get; set; }
        public string Message { get; set; }
        public List<string>? Errors { get; set; }

        public TrackResponse(T? data, string message)
        {
            Success = true;
            this.Data = data;
            this.Message = message;
            Errors = null;
        }

        public TrackResponse(string Message, List<string> Errors = null)
        {
            Success = false;
            Data = default(T);
            this.Message = Message;
            this.Errors = Errors;
        }
    }
}
