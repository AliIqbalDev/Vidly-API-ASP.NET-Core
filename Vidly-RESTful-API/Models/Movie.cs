namespace Vidly_RESTful_API.Models
{
    public class Movie
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int GenreId { get; set; }

        public Genre Genre { get; set; }

        public int NumberInStock { get; set; }

        public decimal DailyRentalRate { get; set; }
    }
}