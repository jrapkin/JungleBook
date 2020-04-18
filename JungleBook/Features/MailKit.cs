using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JungleBook.Features
{
	public static class MailKit
	{
		public static MimeMessage CreateEmail(string name, string from, List<string> listOfRecipients, string messageText)
		{
			MailboxAddress senderAddress = new MailboxAddress(name, from);
			List<MailboxAddress> recipientAddresses = new List<MailboxAddress>();
			foreach(string address in listOfRecipients)
			{
				recipientAddresses.Add(new MailboxAddress(name, address));
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
	}
}
