using AutoMapper;
using TaskOrganizer.Entities;
using TaskOrganizer.ViewModels;

namespace TaskOrganizer.BusinessLogic.Configs
{
    public static class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<Category, CategoryView>();
                config.CreateMap<ChildObjective, ChildObjectiveView>();
                config.CreateMap<ChildObjectiveView, ChildObjective>();

                config.CreateMap<MainObjective, MainObjectiveView>();
                config.CreateMap<MainObjectiveView, MainObjective>();
            });
        }
    }
}
