using Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace Domain.Models
{
	//public class Destination
	//{
	//	public int? DestinationId { get; set; }
	//	public string Name { get; set; }
	//	public Trip Trip { get; set; }
	//	public Address Address { get; set; }
	//	public string PlaceId { get; set; }
	//	public List<Day> Days { get; set; }
	//}
	public class Destination
	{
		public int DestinationId { get; set; }
		public string Name { get; set; }
		public int TripItineraryId { get; set; }
		public Address Address { get; set; }
		public TripItinerary TripItinerary { get; set; }
	}
}
