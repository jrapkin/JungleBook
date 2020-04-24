using System.ComponentModel.DataAnnotations.Schema;

namespace JungleBook.Models
{
	public class Accommodation
	{
		public int AccommodationId { get; set; }
		public string Name { get; set; }
		[ForeignKey("Address")]
		public int AddressId { get; set; }
		public Address Address { get; set; }
	}
}
