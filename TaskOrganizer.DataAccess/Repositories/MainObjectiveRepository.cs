using TaskOrganizer.Entities;
using TaskOrganizer.DataAccess.Interfaces;

namespace TaskOrganizer.DataAccess.Repositories
{
    public class MainObjectiveRepository : BaseRepository<MainObjective>, IMainObjectiveRepository
    {
        public MainObjectiveRepository(string connectionString) : base(connectionString)
        {

        }
    }
}
