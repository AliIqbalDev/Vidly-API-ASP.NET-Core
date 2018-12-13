using System.Threading.Tasks;

namespace Vidly_RESTful_API.Services
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}