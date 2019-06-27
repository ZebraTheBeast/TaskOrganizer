using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskOrganizer.BLL.Services.Inerfaces;
using TaskOrganizer.Entities.Enums;
using TaskOrganizer.ViewModels;
using TaskOrganizer.ViewModels.Shared;

namespace TaskOrganizer.WebApp.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ValuesController : Controller
    {

        private IDashboardService _dashboardService;

        public ValuesController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        [HttpPost]
        [ActionName("GetCategories")]
        public async Task<List<CategoryView>> GetCategories([FromBody]long userId)
        {
            var categories = await _dashboardService.GetCategories(userId);
            return categories;
        }

        [HttpPost]
        [ActionName("AddCategory")]
        public async Task<CategoryView> AddCategory([FromBody]CategoryRequestView requestView)
        {

            var category = await _dashboardService.AddCategory(
                requestView.category.Title,
                requestView.category.Description,
                requestView.userId);

            return category;

        }

        [HttpPost]
        [ActionName("EditCategory")]
        public async Task<string> EditCategory([FromBody]CategoryRequestView requestView)
        {
            await _dashboardService.EditCategory(
                requestView.category.Id,
                requestView.category.Title,
                requestView.category.Description,
                requestView.userId);
            return "";
        }

        [HttpPost]
        [ActionName("DeleteCategory")]
        public async Task<string> DeleteCategory([FromBody]long categoryId)
        {
            await _dashboardService.DeleteCategory(categoryId);

            return "";
        }

        [HttpPost]
        [ActionName("AddMainObjective")]
        public async Task<MainObjectiveView> AddMainObjecitve([FromBody]MainObjectiveRequestView requestView)
        {
            var mainObjective = await _dashboardService.AddMainObjective(
                    requestView.mainObjective,
                    requestView.categoryId);

            return mainObjective;
        }

        [HttpPost]
        [ActionName("EditMainObjective")]
        public async Task<string> EditMainObjective([FromBody]MainObjectiveView mainObjectiveView)
        {
            await _dashboardService.EditMainObjective(mainObjectiveView);

            return "";
        }

        [HttpPost]
        [ActionName("DeleteMainObjective")]
        public async Task<string> DeleteMainObjective([FromBody]long mainObjectiveId)
        {
            await _dashboardService.DeleteMainObjective(mainObjectiveId);

            return "";
        }

        [HttpPost]
        [ActionName("UpdateStatusMainObjective")]
        public async Task<string> UpdateStatusMainObjective([FromBody]UpdateStatusRequestView requestView)
        {
            await _dashboardService.ChangeStatusMainObjective(requestView.objectiveId, (ObjectiveStatus)requestView.statusId);
            return "";
        }


        [HttpPost]
        [ActionName("AddChildObjective")]
        public async Task<ChildObjectiveView> AddChildObjecitve([FromBody]ChildObjectiveRequestView requestView)
        {
            var childObjective = await _dashboardService.AddChildObjective(
                requestView.childObjective,
                requestView.mainObjectiveId);

            return childObjective;
        }

        [HttpPost]
        [ActionName("EditChildObjective")]
        public async Task<string> EditChildObjective([FromBody]ChildObjectiveView childObjectiveView)
        {
            await _dashboardService.EditChildObjective(childObjectiveView);

            return "";
        }

        [HttpPost]
        [ActionName("DeleteChildObjective")]
        public async Task<string> DeleteChildObjective([FromBody]long childObjectiveId)
        {
            await _dashboardService.DeleteChildObjective(childObjectiveId);

            return "";
        }

        [HttpPost]
        [ActionName("UpdateStatusChildObjective")]
        public async Task<string> UpdateStatusChildObjective([FromBody]UpdateStatusRequestView requestView)
        {
            await _dashboardService.ChangeStatusChildObjective(requestView.objectiveId, (ObjectiveStatus)requestView.statusId);
            return "";
        }
    }
}
