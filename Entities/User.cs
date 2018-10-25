using System.ComponentModel.DataAnnotations;
using TaskOrganizer.Entities.Enums;

namespace TaskOrganizer.Entities
{
	public class User : BaseEntity
	{
        [Required]
        public string Name { get; set; }
        [Required]
        public UserType Type { get; set; }
	}
}
