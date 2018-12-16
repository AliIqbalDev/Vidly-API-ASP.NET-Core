using System.Collections.Generic;
using System.Threading.Tasks;
using Vidly_RESTful_API.Models;

namespace Vidly_RESTful_API.Services
{
    public interface IVidlyRepository
    {
        void AddCustomer(Customer customer);

        Task<IEnumerable<Customer>> GetCustomersAsync();

        Task<Customer> GetCustomerAsync(int customerId);

        void DeleteCustomer(Customer customer);

        void AddGenre(Genre genre);

        Task<IEnumerable<Genre>> GetGenresAsync();

        Task<Genre> GetGenreAsync(int genreId);

        void DeleteGenre(Genre genre);

        void AddMovie(Movie movie);

        Task<IEnumerable<Movie>> GetMoviesAsync();

        Task<Movie> GetMovieAsync(int movieId);

        void DeleteMovie(Movie movie);
    }
}