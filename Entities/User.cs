using TaskOrganizer.Entities.Enums;

namespace TaskOrganizer.Entities
{
	public class User : BaseEntity
	{
		public string Name { get; set; }
		public UserType Type { get; set; }
	}
}
