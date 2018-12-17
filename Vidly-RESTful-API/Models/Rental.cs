using System;

namespace Vidly_RESTful_API.Models
{
    public class Rental
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public int MovieId { get; set; }

        public Movie Movie { get; set; }

        public DateTime DateOut { get; set; }

        public DateTime DateReturned { get; set; }

        public decimal RentalFee { get; set; }
    }
}