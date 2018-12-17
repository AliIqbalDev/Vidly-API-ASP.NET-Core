using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Vidly_RESTful_API.Dtos;
using Vidly_RESTful_API.Models;
using Vidly_RESTful_API.Services;

namespace Vidly_RESTful_API.Controllers
{
    [Route("api/rentals")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        private readonly IVidlyRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RentalsController(IVidlyRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetRentals()
        {
            var rentals = await _repository.GetRentalsAsync();

            var rentalsToReturn = _mapper.Map<IEnumerable<RentalDto>>(rentals);

            return Ok(rentalsToReturn);
        }

        [HttpGet("{id}", Name = "GetRental")]
        public async Task<IActionResult> GetRental(int id)
        {
            var rental = await _repository.GetRentalAsync(id);

            if (rental == null) return NotFound();

            var rentalToReturn = _mapper.Map<RentalDto>(rental);

            return Ok(rentalToReturn);
        }

        [HttpPost]
        public async Task<IActionResult> AddRental([FromBody] RentalForCreationDto rentalForCreationDto)
        {
            if (rentalForCreationDto == null) return BadRequest();

            var customer = await _repository.GetCustomerAsync(rentalForCreationDto.CustomerId);
            if (customer == null) return NotFound();

            var movie = await _repository.GetMovieAsync(rentalForCreationDto.MovieId);
            if (movie == null) return NotFound();

            if (movie.NumberInStock == 0) return BadRequest("Movie out of stock");

            var rental = _mapper.Map<Rental>(rentalForCreationDto);
            rental.RentalFee = movie.DailyRentalRate;

            _repository.AddRental(rental);

            movie.NumberInStock--;

            await _unitOfWork.CompleteAsync();

            var rentalToReturn = _mapper.Map<RentalDto>(rental);

            return CreatedAtRoute("GetRental", new {id = rentalToReturn.Id}, rentalToReturn);
        }
    }
}