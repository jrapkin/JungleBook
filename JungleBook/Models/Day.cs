using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace JungleBook.Models
{
	public class Day
	{
		public int DayId { get; set; }
		public DateTime DayOfWeek { get; set; }
		[ForeignKey("Accommodation")]
		public int AccommodationId { get; set; }
		public Accommodation Accommodation {get; set;}
		public List<DayActivity> DayActivities { get; set; }
	}
}
