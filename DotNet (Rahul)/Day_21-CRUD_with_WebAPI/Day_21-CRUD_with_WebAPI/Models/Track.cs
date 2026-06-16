namespace Day_21_CRUD_with_WebAPI.Models
{
    public class Track
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Artist { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public int DurationSeconds { get; set; }
        public int ReleaseYear { get; set; }
        public bool IsDeleted{ get; set; }
    }
}
