using System;
using System.Collections.Generic;

namespace TaskOrganizer.ViewModels
{
    public class MainObjectiveView
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public DateTime? Deadline { get; set; }

        public List<ChildObjectiveView> ChildObjectives { get; set; }

        public MainObjectiveView()
        {
            ChildObjectives = new List<ChildObjectiveView>();
        }
    }
}
