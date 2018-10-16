namespace TaskOrganizer.Entities
{
	public class Category : BaseEntity
	{
		public string Title { get; set; }
		public long UserId { get; set; }
	}
}
