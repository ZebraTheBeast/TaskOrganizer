using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TaskOrganizer.Entities
{
    public class Category : BaseEntity
    {
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }

        [Required]
        public long UserId { get; set; }
        public virtual User User { get; set; }

        public virtual List<MainObjective> MainObjectives { get; set; }
    }
}
