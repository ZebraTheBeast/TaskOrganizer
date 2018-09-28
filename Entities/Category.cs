using TaskOrganizer.Entities;

namespace Entities
{
	public class Category : BaseEntity
	{
		public string Title { get; set; }
		public int UserId { get; set; }
	}
}
