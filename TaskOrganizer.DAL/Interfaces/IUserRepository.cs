using System.Threading.Tasks;
using TaskOrganizer.Entities;

namespace TaskOrganizer.DAL.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetByName(string userName);
    }
}
