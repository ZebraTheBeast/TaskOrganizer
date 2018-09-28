using Entities.Enums;
using TaskOrganizer.Entities;

namespace Entities
{
	public class User : BaseEntity
	{
		public string Name { get; set; }
		public UserType Type { get; set; }
	}
}
