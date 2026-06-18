namespace Day_27_Advanced_Repository_Operations_Asynchronous_Programming.Wrapper
{
    public class MedicleSupplyResponse<T>
    {
        public bool Success { get; set; }
        public T? Data { get; set; }
        public string Message { get; set; }
        public List<string>? Errors { get; set; }

        public MedicleSupplyResponse(T Data, string Message)
        {
            Success = true;
            this.Data = Data;
            this.Message = Message;
            Errors = null;
        }

        public MedicleSupplyResponse(string Message, List<string> Errors = null)
        {
            Success = false;
            Data = default(T);
            this.Message = Message;
            this.Errors = Errors;
        }
    }
}
