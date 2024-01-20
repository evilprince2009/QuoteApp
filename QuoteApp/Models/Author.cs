namespace QuoteApp.Models
{
    public class Author
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Origin { get; set; }

        public Author()
        {
            
        }
    }
}