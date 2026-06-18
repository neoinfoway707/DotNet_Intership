namespace Day_27_Advanced_Repository_Operations_Asynchronous_Programming.Wrapper
{
    public class MedicleSupplyPageResponse<T>
    {
        public bool Success { get; set; }
        public T? Data { get; set; }
        public string Message { get; set; }
        public int Pages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public List<string>? Errors { get; set; }

        public MedicleSupplyPageResponse(T Data, string Message, int Pages, int PageSize, int TotalCount)
        {
            Success = true;
            this.Data = Data;
            this.Message = Message;
            this.Pages = Pages;
            this.PageSize = PageSize;
            this.TotalCount = TotalCount;
            TotalPages = (int)Math.Ceiling((double)TotalCount / PageSize);
            this.Errors = null;
        }
    }
}
