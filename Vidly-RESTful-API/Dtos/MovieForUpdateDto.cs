namespace Vidly_RESTful_API.Dtos
{
    public class MovieForUpdateDto
    {
        public string Title { get; set; }

        public int GenreId { get; set; }

        public int NumberInStock { get; set; }

        public decimal DailyRentalRate { get; set; }
    }
}