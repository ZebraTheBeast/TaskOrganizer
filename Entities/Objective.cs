using Entities.Enums;
using System;
using TaskOrganizer.Entities;

namespace Entities
{
	public class Objective : BaseEntity
	{
		public int CategoryId { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public ObjectiveStatus Status { get; set; }
		public DateTime DeadLine { get; set; }
		public int ParentObjectiveId { get; set; }
	}
}
