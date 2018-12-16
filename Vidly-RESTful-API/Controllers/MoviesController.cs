using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Vidly_RESTful_API.Dtos;
using Vidly_RESTful_API.Models;
using Vidly_RESTful_API.Services;

namespace Vidly_RESTful_API.Controllers
{
    [Route("api/movies")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IVidlyRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MoviesController(IVidlyRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetMovies()
        {
            var movies = await _repository.GetMoviesAsync();

            var moviesToReturn = _mapper.Map<IEnumerable<MovieDto>>(movies);

            return Ok(moviesToReturn);
        }

        [HttpGet("{id}", Name = "GetMovie")]
        public async Task<IActionResult> GetMovie(int id)
        {
            var movie = await _repository.GetMovieAsync(id);

            if (movie == null) return NotFound();

            var movieToReturn = _mapper.Map<MovieDto>(movie);

            return Ok(movieToReturn);
        }

        [HttpPost]
        public async Task<IActionResult> AddMovie([FromBody] MovieForCreationDto movieForCreationDto)
        {
            if (movieForCreationDto == null) return BadRequest();

            var movie = _mapper.Map<Movie>(movieForCreationDto);

            _repository.AddMovie(movie);
            await _unitOfWork.CompleteAsync();

            var movieToReturn = _mapper.Map<MovieDto>(movie);

            return CreatedAtRoute("GetMovie", new {id = movieToReturn.Id}, movieToReturn);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> UpdateMovie(int id, [FromBody] MovieForUpdateDto movieForUpdateDto)
        {
            if (movieForUpdateDto == null) return BadRequest();

            var movie = await _repository.GetMovieAsync(id);

            if (movie == null) return NotFound();

            _mapper.Map(movieForUpdateDto, movie);

            await _unitOfWork.CompleteAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var movie = await _repository.GetMovieAsync(id);

            if (movie == null) return NotFound();

            _repository.DeleteMovie(movie);

            await _unitOfWork.CompleteAsync();

            return NoContent();
        }
    }
}