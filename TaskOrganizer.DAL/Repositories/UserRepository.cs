using TaskOrganizer.DAL.Context;
using TaskOrganizer.DAL.Interfaces;
using TaskOrganizer.Entities;

namespace TaskOrganizer.DataAccess.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(TaskOrganizerContext context) : base(context)
        {

        }
    }
}
