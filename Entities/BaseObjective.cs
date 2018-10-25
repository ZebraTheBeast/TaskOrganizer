using System;
using System.ComponentModel.DataAnnotations;
using TaskOrganizer.Entities.Enums;

namespace TaskOrganizer.Entities
{
    public class BaseObjective : BaseEntity
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public ObjectiveStatus Status { get; set; }
        public DateTime? DeadLine { get; set; }

        [Required]
        public long CategoryId { get; set; }
        public virtual Category Category { get; set; }

    }
}
