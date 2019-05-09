using System.Threading.Tasks;
using TaskOrganizer.Entities;
using TaskOrganizer.Entities.Enums;

namespace TaskOrganizer.DataAccess.Interfaces
{
    public interface IMainObjectiveRepository : IBaseRepository<MainObjective>
	{
        Task UpdateStatus(long mainObjectiveId, ObjectiveStatus objectiveStatus);
    }
}
