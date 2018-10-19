using TaskOrganizer.Entities;

namespace Entities
{
    public class ChildObjective : BaseObjective
    {
        public long MainObjectiveId { get; set; }
        public virtual MainObjective MainObjective { get; set; }
    }
}
