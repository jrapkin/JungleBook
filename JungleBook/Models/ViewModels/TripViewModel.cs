using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JungleBook.Models.ViewModels
{
	public class TripViewModel
	{
		public Traveler TravelerLoggedIn { get; set; }
		public List<Traveler> TravelBuddies { get; set; }
		public UserProfile UserProfile { get; set; }
		public List<DayActivity> DayActivities { get; set; }
	}
}
