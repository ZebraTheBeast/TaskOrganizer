using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskOrganizer.BLL.Services.Inerfaces;
using TaskOrganizer.DAL.Interfaces;
using TaskOrganizer.Entities;
using TaskOrganizer.Entities.Enums;
using TaskOrganizer.ViewModels;

namespace TaskOrganizer.BLL.Services
{
    public class DashBoardService : IDashboardService
    {
        private ICategoryRepository _categoryRepository;
        private IChildObjectiveRepository _childObjectiveRepository;
        private IMainObjectiveRepository _mainObjectiveRepository;
 
        public DashBoardService(
            ICategoryRepository categoryRepository,
            IChildObjectiveRepository childObjectiveRepository,
            IMainObjectiveRepository mainObjectiveRepository)
        {
            _categoryRepository = categoryRepository;
            _childObjectiveRepository = childObjectiveRepository;
            _mainObjectiveRepository = mainObjectiveRepository;
        }

        public async Task<CategoryView> AddCategory(string title, string description, long userId)
        {
            var category = new Category();
            category.Title = title;
            category.Description = description;
            category.UserId = userId;

            var newCategory = await _categoryRepository.Add(category);
            var categoryView = new CategoryView();
            categoryView = Mapper.Map<Category, CategoryView>(newCategory);

            return categoryView;
        }

        public async Task EditCategory(long categoryId, string title, string description, long userId)
        {
            var category = new Category();
            category.Id = categoryId;
            category.Title = title;
            category.Description = description;
            category.UserId = userId;

            await _categoryRepository.Update(category);
        }

        public async Task EditMainObjective(MainObjectiveView mainObjectiveView)
        {
            var mainObjective = await _mainObjectiveRepository.Get(mainObjectiveView.Id);
          
            mainObjective.Id = mainObjectiveView.Id;
            mainObjective.Title = mainObjectiveView.Title;
            mainObjective.Description = mainObjectiveView.Description;
            mainObjective.DeadLine = mainObjectiveView.Deadline;
   
            await _mainObjectiveRepository.Update(mainObjective);
        }

        public async Task EditChildObjective(ChildObjectiveView childObjectiveView)
        {
            var childObjective = await _childObjectiveRepository.Get(childObjectiveView.Id);

            childObjective.Id = childObjectiveView.Id;
            childObjective.Title = childObjectiveView.Title;
            childObjective.Description = childObjectiveView.Description;
            childObjective.DeadLine = childObjectiveView.Deadline;

            await _childObjectiveRepository.Update(childObjective);
        }

        public async Task<ChildObjectiveView> AddChildObjective(ChildObjectiveView childObjectiveView, long mainObjectiveId)
        {
            var childObjective = new ChildObjective();
            childObjective = Mapper.Map<ChildObjectiveView, ChildObjective>(childObjectiveView);
            childObjective.MainObjectiveId = mainObjectiveId;
            childObjective.Status = ObjectiveStatus.New;

            var newChildObjective = await _childObjectiveRepository.Add(childObjective);
            var newChildObjectiveView = new ChildObjectiveView();
            newChildObjectiveView = Mapper.Map<ChildObjective, ChildObjectiveView>(newChildObjective);

            return newChildObjectiveView;
        }

        public async Task<MainObjectiveView> AddMainObjective(MainObjectiveView mainObjectiveView, long categoryId)
        {
            var mainObjective = Mapper.Map<MainObjectiveView, MainObjective>(mainObjectiveView);
            mainObjective.CategoryId = categoryId;
            mainObjective.Status = ObjectiveStatus.New;

            var newMainObjective = await _mainObjectiveRepository.Add(mainObjective);
            var newMainObjectiveView = Mapper.Map<MainObjective, MainObjectiveView>(newMainObjective);

            return newMainObjectiveView;
        }

        public async Task ChangeStatusChildObjective(long childObjectiveid, ObjectiveStatus objectiveStatus)
        {
            await _childObjectiveRepository.UpdateStatus(childObjectiveid, objectiveStatus);
        }

        public async Task ChangeStatusMainObjective(long mainObjectiveId, ObjectiveStatus objectiveStatus)
        {
            await _mainObjectiveRepository.UpdateStatus(mainObjectiveId, objectiveStatus);
        }

        public async Task DeleteCategory(long categoryId)
        {
            var category = new Category();
            category.Id = categoryId;
            await _categoryRepository.Remove(category);
        }

        public async Task DeleteChildObjective(long childObjectiveId)
        {
            var childObjective = new ChildObjective();
            childObjective.Id = childObjectiveId;
            await _childObjectiveRepository.Remove(childObjective);
        }

        public async Task DeleteMainObjective(long mainObjectiveId)
        {
            var mainObjective = new MainObjective();
            mainObjective.Id = mainObjectiveId;
            await _mainObjectiveRepository.Remove(mainObjective);
        }

        public async Task<List<CategoryView>> GetCategories(long userId)
        {
            var categoriesView = new List<CategoryView>();
            var categories = await _categoryRepository.GetCategoriesByUserId(userId);
            categoriesView = Mapper.Map<List<Category>, List<CategoryView>>(categories);
            return categoriesView;
        }
    }
}
