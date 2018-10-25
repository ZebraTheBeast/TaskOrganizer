using System.ComponentModel.DataAnnotations;

namespace TaskOrganizer.Entities
{
	public class Category : BaseEntity
	{
        [Required]
        public string Title { get; set; }
        [Required]
        public long UserId { get; set; }
	}
}
