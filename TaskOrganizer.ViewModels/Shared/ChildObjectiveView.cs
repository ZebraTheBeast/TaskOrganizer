using System;

namespace TaskOrganizer.ViewModels
{
    public class ChildObjectiveView
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public DateTime? Deadline { get; set; }
    }
}
