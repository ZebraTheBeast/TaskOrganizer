using System.Collections.Generic;

namespace TaskOrganizer.ViewModels
{
    public class CategoryView
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<MainObjectiveView> MainObjectives { get; set; }

        public CategoryView()
        {
            MainObjectives = new List<MainObjectiveView>();
        }
    }
}
