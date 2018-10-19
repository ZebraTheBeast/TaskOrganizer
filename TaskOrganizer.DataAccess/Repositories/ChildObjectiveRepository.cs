using Entities;
using TaskOrganizer.DataAccess.Interfaces;

namespace TaskOrganizer.DataAccess.Repositories
{
    public class ChildObjectiveRepository : GenericRepository<ChildObjective>, IChildObjectiveRepository
    {
        public ChildObjectiveRepository(string connectionString) : base(connectionString)
        {

        }
    }
}
