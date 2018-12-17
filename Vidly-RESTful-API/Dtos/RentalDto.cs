using System;

namespace Vidly_RESTful_API.Dtos
{
    public class RentalDto
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public int MovieId { get; set; }

        public DateTime DateOut { get; set; }

        public DateTime DateReturned { get; set; }

        public decimal RentalFee { get; set; }
    }
}