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

	}
}
