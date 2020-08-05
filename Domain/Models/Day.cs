using System;
using System.Collections.Generic;

namespace Domain.Models
{
	public class Day
	{
		public Day()
		{
			DayActivities = new HashSet<DayActivity>();
		}
		public int DayId { get; set; }
		public int? AccommodationId { get; set; }
		public int TripItineraryId { get; set; }
		public DateTime DayOfWeek { get; set; }
		public Accommodation Accommodation { get; set; }
		public TripItinerary TripItinerary { get; set; }
		public virtual ICollection<DayActivity> DayActivities { get; set; }

	}
}
