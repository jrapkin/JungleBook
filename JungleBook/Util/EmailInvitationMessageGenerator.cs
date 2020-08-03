using JungleBook.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JungleBook.Util
{
	public static class EmailInvitationMessageGenerator
	{
		public static string CreateInvitationMessageWithInvitationCode(TripInvitationViewModel viewModel)
		{
			string message = $"\n\n{viewModel.TravelerLoggedIn.FirstName} has invited you to go on an adventure! \n Follow the link to register an account and join" +
			$" {viewModel.TravelerLoggedIn.FirstName} in the fun. But before you do, you'll need to enter a super secret adventure code.\n" +
			$"Once registered, look for the not so secret join adventure button and enter the following two part code: {viewModel.TravelerLoggedIn.UserName}, {viewModel.Trip.Name}.\n" +
			$"Happy Travels!\n" +
			"https://localhost:44324/Identity/Account/Register";
			return message;
		}
	}
}
