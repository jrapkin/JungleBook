using System;
using System.Collections.Generic;

namespace Domain.Models
{
	public class Day
	{
		public int DayId { get; set; }
		public DateTime DayOfWeek { get; set; }
		public int? AccommodationId { get; set; }
		public Accommodation Accommodation { get; set; }
		public Destination Destination { get; set; }
		public List<DayActivity> DayActivities { get; set; }

	}
}
