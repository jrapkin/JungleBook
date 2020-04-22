using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JungleBook.Models.ViewModels
{
	public class TripViewModel
	{
		public TripViewModel()
		{
		}
		public Traveler TravelerLoggedIn { get; set; }
		public List<Traveler> TravelBuddies { get; set; }
		public UserProfile UserProfile { get; set; }
		public Trip Trip { get; set; }
		public List<DayActivity> DayActivities { get; set; }
		public List<int> selectedDestinations { get; set; }
		public MultiSelectList DestinationOptions { get; set; }
	}
}
