using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vidly_RESTful_API.Contexts;
using Vidly_RESTful_API.Models;

namespace Vidly_RESTful_API.Services
{
    public class VidlyRepository : IVidlyRepository
    {
        private readonly VidlyContext _context;

        public VidlyRepository(VidlyContext context)
        {
            _context = context;
        }

        public void AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
        }

        public async Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer> GetCustomerAsync(int customerId)
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.Id == customerId);
        }

        public void DeleteCustomer(Customer customer)
        {
            _context.Customers.Remove(customer);
        }

        public void AddGenre(Genre genre)
        {
            _context.Genres.Add(genre);
        }

        public async Task<IEnumerable<Genre>> GetGenresAsync()
        {
            return await _context.Genres.ToListAsync();
        }

        public async Task<Genre> GetGenreAsync(int genreId)
        {
            return await _context.Genres.FirstOrDefaultAsync(g => g.Id == genreId);
        }

        public void DeleteGenre(Genre genre)
        {
            _context.Genres.Remove(genre);
        }

        public void AddMovie(Movie movie)
        {
            _context.Movies.Add(movie);
        }

        public async Task<IEnumerable<Movie>> GetMoviesAsync()
        {
            return await _context.Movies.ToListAsync();
        }

        public async Task<Movie> GetMovieAsync(int movieId)
        {
            return await _context.Movies.FirstOrDefaultAsync(m => m.Id == movieId);
        }

        public void DeleteMovie(Movie movie)
        {
            _context.Movies.Remove(movie);
        }

        public void AddRental(Rental rental)
        {
            _context.Rentals.Add(rental);
        }

        public async Task<IEnumerable<Rental>> GetRentalsAsync()
        {
            return await _context.Rentals.ToListAsync();
        }

        public async Task<Rental> GetRentalAsync(int rentalId)
        {
            return await _context.Rentals.FirstOrDefaultAsync(r => r.Id == rentalId);
        }
    }
}