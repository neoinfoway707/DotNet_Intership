namespace Day_24_Understanding_Repository_Pattern.Models
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
