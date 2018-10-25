using TaskOrganizer.DataAccess.Interfaces;
using TaskOrganizer.Entities;

namespace TaskOrganizer.DataAccess.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(string connectionString) : base(connectionString)
        {

        }
    }
}
