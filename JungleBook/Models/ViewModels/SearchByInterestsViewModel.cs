using Application.Dtos;
using Domain.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;


namespace JungleBook.Models.ViewModels
{
	public class SearchByInterestsViewModel
	{
		public SearchByInterestsViewModel()
		{

		}
		public Trip Trip { get; set; }
		public MultiSelectList DestinationOptions { get; set; }
		public List<SelectListItem> Interests { get; set; }
		public List<int> SelectedDestinations { get; set; }
		public string SelectedInterest { get; set; }
		public CampingResult CampingResults { get; set; }
		public HikingResult HikingResult { get; set; }
		public PlaceResults PlaceResults { get; set; }
		public List<HikingResult> ListOfHikingResults { get; set; }
		public List<PlaceResults> ListOfPlaceResults { get; set; }
	}
}
