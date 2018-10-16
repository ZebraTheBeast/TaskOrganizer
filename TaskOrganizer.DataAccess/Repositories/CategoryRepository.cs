using TaskOrganizer.DataAccess.Interfaces;
using TaskOrganizer.Entities;

namespace TaskOrganizer.DataAccess.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(string connectionString) : base(connectionString)
        {

        }
    }
}
