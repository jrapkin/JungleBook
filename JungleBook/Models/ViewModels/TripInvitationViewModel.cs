using Application.Dtos;
using Domain.Models;

namespace JungleBook.Models.ViewModels
{
	public class TripInvitationViewModel
	{
		public Traveler TravelerLoggedIn { get; set; }
		public Trip Trip { get; set; }
		public Message Message { get; set; }
		public bool? SentSuccessfully { get; set; }

	}
}
