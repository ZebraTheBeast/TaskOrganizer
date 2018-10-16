using TaskOrganizer.DataAccess.Interfaces;
using TaskOrganizer.Entities;

namespace TaskOrganizer.DataAccess.Repositories
{
    public class ObjectiveRepository : GenericRepository<Objective>, IObjectiveRepository
    {
        public ObjectiveRepository(string connectionString) : base(connectionString)
        {

        }
    }
}
