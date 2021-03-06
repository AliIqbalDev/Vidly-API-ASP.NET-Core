﻿namespace Vidly_RESTful_API.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public GenreDto Genre { get; set; }

        public int NumberInStock { get; set; }

        public decimal DailyRentalRate { get; set; }
    }
}