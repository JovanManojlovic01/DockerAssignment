namespace BookApi.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int YearOfRelease { get; set; }
        public string imageURL { get; set; }
        public string Description { get; set; }
    }
}
