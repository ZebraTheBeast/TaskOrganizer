using System.Collections.Generic;
using System.Threading.Tasks;
using TaskOrganizer.Entities;

namespace TaskOrganizer.DataAccess.Interfaces
{
	public interface ICategoryRepository : IBaseRepository<Category>
	{
        Task<List<Category>> GetCategoriesByUserId(long userId);
	}
}
