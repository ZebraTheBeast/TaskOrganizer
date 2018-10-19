using System.Collections.Generic;
using TaskOrganizer.Entities;

namespace Entities
{
    public class MainObjective : BaseObjective
    {
        public string Description { get; set; }

        public virtual List<ChildObjective> ChildObjectives { get; set; }
    }
}
