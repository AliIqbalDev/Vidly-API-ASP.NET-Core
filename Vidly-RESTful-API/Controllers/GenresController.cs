using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Vidly_RESTful_API.Dtos;
using Vidly_RESTful_API.Models;
using Vidly_RESTful_API.Services;

namespace Vidly_RESTful_API.Controllers
{
    [Route("api/genres")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IVidlyRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GenresController(IVidlyRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetGenres()
        {
            var genres = await _repository.GetGenresAsync();

            var genresToReturn = _mapper.Map<IEnumerable<GenreDto>>(genres);

            return Ok(genresToReturn);
        }

        [HttpGet("{id}", Name = "GetGenre")]
        public async Task<IActionResult> GetGenre(int id)
        {
            var genre = await _repository.GetGenreAsync(id);

            if (genre == null) return NotFound();

            var genreToReturn = _mapper.Map<GenreDto>(genre);

            return Ok(genreToReturn);
        }

        [HttpPost]
        public async Task<IActionResult> AddGenre([FromBody] GenreForCreationDto genreForCreationDto)
        {
            if (genreForCreationDto == null) return BadRequest();

            var genre = _mapper.Map<Genre>(genreForCreationDto);

            _repository.AddGenre(genre);
            await _unitOfWork.CompleteAsync();

            var genreToReturn = _mapper.Map<GenreDto>(genre);

            return CreatedAtRoute("GetGenre", new {id = genreToReturn.Id}, genreToReturn);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGenre(int id, [FromBody] GenreForUpdateDto genreForUpdateDto)
        {
            if (genreForUpdateDto == null) return BadRequest();

            var genre = await _repository.GetGenreAsync(id);

            if (genre == null) return NotFound();

            _mapper.Map(genreForUpdateDto, genre);

            await _unitOfWork.CompleteAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenre(int id)
        {
            var genre = await _repository.GetGenreAsync(id);

            if (genre == null) return NotFound();

            _repository.DeleteGenre(genre);

            await _unitOfWork.CompleteAsync();

            return NoContent();
        }
    }
}