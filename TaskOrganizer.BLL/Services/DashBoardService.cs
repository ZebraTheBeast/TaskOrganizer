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
        private IUserRepository _userRepository;

        public DashBoardService(
            ICategoryRepository categoryRepository,
            IChildObjectiveRepository childObjectiveRepository,
            IMainObjectiveRepository mainObjectiveRepository,
            IUserRepository userRepository)
        {
            _categoryRepository = categoryRepository;
            _childObjectiveRepository = childObjectiveRepository;
            _mainObjectiveRepository = mainObjectiveRepository;
            _userRepository = userRepository;
        }

        public async Task<CategoryView> AddCategory(string title, long userId)
        {
            var category = new Category();
            category.Title = title;
            category.UserId = userId;

            var newCategory = await _categoryRepository.Add(category);
            var categoryView = new CategoryView();
            categoryView = Mapper.Map<Category, CategoryView>(newCategory);

            return categoryView;
        }

        public async Task<ChildObjectiveView> AddChildObjective(ChildObjectiveView childObjectiveView, long mainObjectiveId)
        {
            var childObjective = new ChildObjective();
            childObjective = Mapper.Map<ChildObjectiveView, ChildObjective>(childObjectiveView);
            childObjective.MainObjectiveId = mainObjectiveId;

            var newChildObjective = await _childObjectiveRepository.Add(childObjective);
            var newChildObjectiveView = new ChildObjectiveView();
            newChildObjectiveView = Mapper.Map<ChildObjective, ChildObjectiveView>(newChildObjective);

            return newChildObjectiveView;
        }

        public async Task<MainObjectiveView> AddMainObjective(MainObjectiveView mainObjectiveView, long categoryId)
        {
            var mainObjective = new MainObjective();
            mainObjective = Mapper.Map<MainObjectiveView, MainObjective>(mainObjectiveView);
            mainObjective.CategoryId = categoryId;

            var newMainObjective = await _mainObjectiveRepository.Add(mainObjective);
            var newMainObjectiveView = new MainObjectiveView();
            newMainObjectiveView = Mapper.Map<MainObjective, MainObjectiveView>(newMainObjective);

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

        public async Task<List<CategoryView>> TakeAllCategory(long userId)
        {
            var categoriesView = new List<CategoryView>();
            var categories = await _categoryRepository.GetCategoriesByUserId(userId);
            // чекнуть что приходит и как мапится
            return categoriesView;
        }
    }
}
