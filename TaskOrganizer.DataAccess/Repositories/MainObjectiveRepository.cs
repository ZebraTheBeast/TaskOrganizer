using TaskOrganizer.DataAccess.Interfaces;
using TaskOrganizer.Entities;

namespace TaskOrganizer.DataAccess.Repositories
{
    public class MainObjectiveRepository : GenericRepository<MainObjectiveRepository>, IMainObjectiveRepository
    {
        public MainObjectiveRepository(string connectionString) : base(connectionString)
        {

        }
    }
}
