using System;

namespace TaskOrganizer.ViewModels
{
    public class ChildObjectiveView
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }
        public DateTime? DeadLine { get; set; }
    }
}
