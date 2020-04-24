using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

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
		public Message Message { get; set; }
		//for partial view
		public string Location { get; set; }
		public string Keyword { get; set; }
		public List<SelectListItem> Interests { get; set; }
		public string SelectedInterest { get; set; }
		public EventSearchResult SearchResults { get; set; }
		public CampingResult CampingResults { get; set; }
		public HikingResult HikingResult { get; set; }
		public PlaceResults PlaceResults { get; set; }

	}
}
