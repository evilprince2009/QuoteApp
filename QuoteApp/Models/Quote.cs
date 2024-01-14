namespace QuoteApp.Models
{
    public class Quote
    {
        public int Id { get; set; }
        public required string Quotation { get; set; }
        public required string Author { get; set; }
        public required string Genre { get; set; }

        public Quote()
        {

        }
    }
}
