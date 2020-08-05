using Domain.ValueObjects;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
	public class Activity
	{
		public Activity()
		{
			DayActivities = new HashSet<DayActivity>();
		}
		public int? ActivityId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public Address Address { get; set; }
		public virtual ICollection<DayActivity> DayActivities { get; set; }
	}
}
