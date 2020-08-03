using Application.Dtos;
using Domain.Models;

namespace JungleBook.Models.ViewModels
{
	public class EventSearchViewModel
	{
		public Trip Trip { get; set; }
		public string Location { get; set; }
		public string Keyword { get; set; }
		public EventSearchResult SearchResults { get; set; }
		public EventSearchViewModel()
		{

		}

	}
}
