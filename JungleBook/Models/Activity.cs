using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace JungleBook.Models
{
	public class Activity
	{
		public int? ActivityId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		[ForeignKey("Address")]
		public int AddressId { get; set; }
		public Address Address { get; set; }
		public List<DayActivity> DayActivities { get; set; }
	}
}
