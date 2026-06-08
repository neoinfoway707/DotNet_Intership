namespace Day_8_CodeFirst_Relationships_in_MVC.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Book>? Books { get; set; }
    }
}
