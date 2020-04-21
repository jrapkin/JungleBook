

namespace JungleBook.Models
{
	public class Address
	{
		public int AddressId { get; set; }
		public string Street { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string County { get; set; }
		public string Region { get; set; }
		public string Country { get; set; }
		public double? Latitude { get; set; }
		public double? Longitude { get; set; }
	}
}
