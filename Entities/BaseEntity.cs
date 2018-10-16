using System;
using System.ComponentModel.DataAnnotations;

namespace TaskOrganizer.Entities
{
	public class BaseEntity
    {
        [Key]
		public long Id { get; set; }
		public DateTime CreationDate { get; set; }

		public BaseEntity()
		{
			CreationDate = DateTime.Now;
		}
    }
}
