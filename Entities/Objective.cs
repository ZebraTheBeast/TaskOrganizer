using System;
using System.Collections.Generic;
using TaskOrganizer.Entities.Enums;

namespace TaskOrganizer.Entities
{
    public class Objective : BaseEntity
    {

        public string Title { get; set; }
        public string Description { get; set; }
        public ObjectiveStatus Status { get; set; }
        public DateTime DeadLine { get; set; }

        public long ParentObjectiveId { get; set; }
        public virtual Objective ParentObjective { get; set; }

        public long CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public virtual List<Objective> ChildObjectives { get; set; }

    }
}
