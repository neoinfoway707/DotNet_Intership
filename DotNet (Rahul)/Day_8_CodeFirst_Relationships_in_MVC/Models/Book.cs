namespace Day_8_CodeFirst_Relationships_in_MVC.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int year { get; set; }

        public int AuthorId { get; set; }
        public Author? Author { get; set; }

        public ICollection<Category>? Categories { get; set; }
    }
}
