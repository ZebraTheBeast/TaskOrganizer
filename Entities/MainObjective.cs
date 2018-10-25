using System.Collections.Generic;

namespace TaskOrganizer.Entities
{
    public class MainObjective : BaseObjective
    {
        public string Description { get; set; }

        public virtual List<ChildObjective> ChildObjectives { get; set; }
    }
}
