using System.Collections.Generic;
using System.Threading.Tasks;
using TaskOrganizer.Entities.Enums;
using TaskOrganizer.ViewModels;

namespace TaskOrganizer.BLL.Services.Inerfaces
{
    public interface IDashboardService
    {
        Task<CategoryView> AddCategory(string title, string description, long userId);
        Task EditCategory(long categoryId, string title, string description, long userId);
        Task DeleteCategory(long categoryId);
        Task<List<CategoryView>> GetCategories(long userId);

        Task<MainObjectiveView> AddMainObjective(MainObjectiveView mainObjective, long categoryId);
        Task EditMainObjective(MainObjectiveView mainObjective);
        Task DeleteMainObjective(long mainObjectiveId);
        Task ChangeStatusMainObjective(long mainObjectiveId, ObjectiveStatus objectiveStatus);

        Task<ChildObjectiveView> AddChildObjective(ChildObjectiveView childObjective, long mainObjectiveId);
        Task EditChildObjective(ChildObjectiveView childObjectiveView);
        Task DeleteChildObjective(long childObjectiveId);
        Task ChangeStatusChildObjective(long childObjectiveid, ObjectiveStatus objectiveStatus);
    }
}
