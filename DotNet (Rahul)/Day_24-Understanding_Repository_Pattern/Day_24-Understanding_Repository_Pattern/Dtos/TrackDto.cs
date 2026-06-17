using System.ComponentModel.DataAnnotations;

namespace Day_24_Understanding_Repository_Pattern.Dtos
{
    public class TrackDto
    {
        [Required(ErrorMessage = "Track title is required.")]
        [StringLength(200, ErrorMessage = "Title cannot exceed 200 characters.")]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage = "Artist name is required.")]
        [StringLength(150, ErrorMessage = "Artist name cannot exceed 150 characters.")]
        public string Artist { get; set; } = null!;

        [Required(ErrorMessage = "Genre designation is required.")]
        [StringLength(50, ErrorMessage = "Genre cannot exceed 50 characters.")]
        public string Genre { get; set; } = null!;

        [Required(ErrorMessage = "Track duration is required.")]
        [Range(1, 3600, ErrorMessage = "Duration must be between 1 second and 3600 seconds (1 hour).")]
        public int DurationSeconds { get; set; }

        [Required(ErrorMessage = "Release year is required.")]
        [Range(1800, 2026, ErrorMessage = "Release year must be between 1800 and the current year (2026).")]
        public int ReleaseYear { get; set; }
    }
}
