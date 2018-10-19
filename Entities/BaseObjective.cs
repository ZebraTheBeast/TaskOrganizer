using System;
using TaskOrganizer.Entities.Enums;

namespace TaskOrganizer.Entities
{
    public class BaseObjective : BaseEntity
    {
        public string Title { get; set; }
        public ObjectiveStatus Status { get; set; }
        public DateTime? DeadLine { get; set; }

        public long CategoryId { get; set; }
        public virtual Category Category { get; set; }

    }
}
