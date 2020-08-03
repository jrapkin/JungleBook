using MailKit.Net.Smtp;
using MimeKit;
using System.Collections.Generic;

namespace Infrastructure.Services
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
		public static bool SendEmailInvitation(MimeMessage message, string email, string password)
		{
			try
			{
				using (SmtpClient client = new SmtpClient())
				{
					client.ServerCertificateValidationCallback = (s, c, h, e) => true;
					client.Connect("smtp.gmail.com", 587, false);
					client.Authenticate(email, password);
					client.Send(message);
					client.Disconnect(true);
					return true;
				};
			}
			catch
			{
				return false;
			}
		}
	}
}
