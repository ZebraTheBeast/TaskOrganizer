using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TaskOrganizer.Entities.Enums;

namespace TaskOrganizer.Entities
{
	public class User : BaseEntity
	{
        [Required]
        public string Username { get; set; }
        [Required]
        
        public string Password { get; set; }

        public virtual List<Category> Categories { get; set; }
	}
}
