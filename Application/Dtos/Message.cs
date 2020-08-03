using System.ComponentModel.DataAnnotations;

namespace Application.Dtos
{
	public class Message
	{
		public int MessageId { get; set; }
		[Display(Name = "From")]
		public string SenderAddress { get; set; }
		[Display(Name = "To")]
		public string RecipientAddress { get; set; }
		[Display(Name = "Message")]
		public string MessageBody { get; set; }
	}
}
