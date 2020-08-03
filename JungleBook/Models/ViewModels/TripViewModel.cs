using Application.Dtos;
using Domain.Models;
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
		public List<int> SelectedDestinations { get; set; }
		public MultiSelectList DestinationOptions { get; set; }
		//for partial view
		public List<SelectListItem> Interests { get; set; }
		public Message Message { get; set; }
	}
}
