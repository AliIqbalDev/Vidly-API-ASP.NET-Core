using System.Threading.Tasks;
using Vidly_RESTful_API.Contexts;

namespace Vidly_RESTful_API.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly VidlyContext _context;

        public UnitOfWork(VidlyContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}