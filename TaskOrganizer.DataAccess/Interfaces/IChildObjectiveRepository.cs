using System.Threading.Tasks;
using TaskOrganizer.Entities;
using TaskOrganizer.Entities.Enums;

namespace TaskOrganizer.DataAccess.Interfaces
{
    public interface IChildObjectiveRepository : IBaseRepository<ChildObjective>
	{
        Task UpdateStatus(long childObjectiveId, ObjectiveStatus objectiveStatus);
	}
}
