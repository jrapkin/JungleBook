using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace JungleBook.Models
{
	public class Destination
	{
		public int? DestinationId { get; set; }
		public string Name { get; set; }
		public DateTime ArrivalDate { get; set; }
		public DateTime DepartureDate { get; set; }
		public Trip Trip { get; set; }
		public int AddressId { get; set; }
		public Address Address { get; set; }
		public string PlaceId { get; set; }
		public List<Day> Days { get; set; }
	}
}
