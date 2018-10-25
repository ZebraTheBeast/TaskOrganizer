using System.ComponentModel.DataAnnotations;

namespace TaskOrganizer.Entities
{
    public class ChildObjective : BaseObjective
    {
        [Required]
        public long MainObjectiveId { get; set; }
        public virtual MainObjective MainObjective { get; set; }
    }
}
