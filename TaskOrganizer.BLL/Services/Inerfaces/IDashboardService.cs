using System.Collections.Generic;
using System.Threading.Tasks;
using TaskOrganizer.Entities.Enums;
using TaskOrganizer.ViewModels;

namespace TaskOrganizer.BLL.Services.Inerfaces
{
    public interface IDashboardService
    {
        Task<CategoryView> AddCategory(string title, long userId);
        Task DeleteCategory(long categoryId);
        Task<List<CategoryView>> TakeAllCategory(long userId);

        Task<MainObjectiveView> AddMainObjective(MainObjectiveView mainObjective, long categoryId);
        Task DeleteMainObjective(long mainObjectiveId);
        Task ChangeStatusMainObjective(long mainObjectiveId, ObjectiveStatus objectiveStatus);

        Task<ChildObjectiveView> AddChildObjective(ChildObjectiveView childObjective, long mainObjectiveId);
        Task DeleteChildObjective(long childObjectiveId);
        Task ChangeStatusChildObjective(long childObjectiveid, ObjectiveStatus objectiveStatus);
    }
}
