using JungleBook.Models.ViewModels;
using MailKit.Net.Smtp;
using MimeKit;
using System.Collections.Generic;

namespace JungleBook.Services
{
	public static class EmailInvitation
	{
		public static MimeMessage CreateEmail(string from, List<string> listOfRecipients, string messageText)
		{
			MailboxAddress senderAddress = new MailboxAddress("", from);
			List<MailboxAddress> recipientAddresses = new List<MailboxAddress>();
			foreach (string address in listOfRecipients)
			{
				recipientAddresses.Add(new MailboxAddress("", address));
			}
			return CreateEmail(senderAddress, recipientAddresses, messageText);
		}
		public static MimeMessage CreateEmail(MailboxAddress senderAddress, List<MailboxAddress> listOfRecipients, string messageText)
		{
			MimeMessage message = new MimeMessage();
			message.From.Add(senderAddress);
			foreach (MailboxAddress address in listOfRecipients)
			{
				message.To.Add(address);
			}
			message.Body = new TextPart("plain")
			{
				Text = messageText
			};
			return message;
		}
		public static void SendEmailInvitation(MimeMessage message, string email, string password)
		{
			using (SmtpClient client = new SmtpClient())
			{
				client.ServerCertificateValidationCallback = (s, c, h, e) => true;
				client.Connect("smtp.gmail.com", 587, false);
				client.Authenticate(email, password);
				client.Send(message);
				client.Disconnect(true);
			};
		}

		public static string CreateInvitationMessageWithInvitationCode(TripViewModel viewModel)
		{
			string message = $"\n\n{viewModel.TravelerLoggedIn.FirstName} has invited you to go on an adventure! \n Follow the link to register an account and join" +
			$"{viewModel.TravelerLoggedIn.FirstName} in the fun. But before you do, you'll need to enter a super secret adventure code.\n" +
			$"Once registered, look for the not so secret join adventure button and enter the following two part code: {viewModel.TravelerLoggedIn.UserName}, {viewModel.Trip.Name}.\n" +
			$"Happy Travels!\n" +
			"https://localhost:44324/Identity/Account/Register";
			return message;
		}
	}
}
