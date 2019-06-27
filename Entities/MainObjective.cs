using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TaskOrganizer.Entities
{
    public class MainObjective : BaseObjective
    {
        public virtual List<ChildObjective> ChildObjectives { get; set; }

        [Required]
        public long CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
