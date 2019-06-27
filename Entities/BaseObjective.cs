using System;
using System.ComponentModel.DataAnnotations;
using TaskOrganizer.Entities.Enums;

namespace TaskOrganizer.Entities
{
    public class BaseObjective : BaseEntity
    {
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public ObjectiveStatus Status { get; set; }
        public DateTime? DeadLine { get; set; }

    }
}
