using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;

namespace QuoteApp.Models
{
    public class DirtyQuotes
    {
        public int Id { get; set; }
        public required string Quote { get; set; }
        public required string Author { get; set; }
        public required string Genre { get; set; }

        public DirtyQuotes()
        {
            
        }
    }
}
