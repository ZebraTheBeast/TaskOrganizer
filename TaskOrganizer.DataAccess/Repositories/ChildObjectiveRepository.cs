using TaskOrganizer.DataAccess.Interfaces;
using TaskOrganizer.Entities;

namespace TaskOrganizer.DataAccess.Repositories
{
    public class ChildObjectiveRepository : BaseRepository<ChildObjective>, IChildObjectiveRepository
    {
        public ChildObjectiveRepository(string connectionString) : base(connectionString)
        {

        }
    }
}
