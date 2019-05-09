using System.Collections.Generic;
using System.Threading.Tasks;

namespace TaskOrganizer.DataAccess.Interfaces
{
	public interface IBaseRepository<TEntity> where TEntity : class
	{
		Task<TEntity> Add(TEntity item);
		Task AddMultiple(List<TEntity> items);
		Task Update(TEntity item);
		Task Remove(TEntity item);
		Task<TEntity> Get(long id);
		Task<List<TEntity>> GetAll();
	}
}
