using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ValueObjects
{
	public class Address : ValueObject
	{
		private Address()
		{
		}
		public Address(string street, string city, string state, string country, double latitude, double longitude)
		{
			Street = street;
			City = city;
			State = state;
			Country = country;
			Latitude = latitude;
			Longitude = longitude;
		}
		public Address(string city, string state, string country, double latitude, double longitude)
		{
			City = city;
			State = state;
			Country = country;
			Latitude = latitude;
			Longitude = longitude;
		}
		public string Street { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string Country { get; set; }
		public double? Latitude { get; set; }
		public double? Longitude { get; set; }

		protected override IEnumerable<object> GetAtomicValues()
		{
			// Using a yield return statement to return each element one at a time
			if (Street != null)
			{
				yield return Street;
			}
			yield return City;
			yield return State;
			yield return Country;
			if (Latitude != null)
			{
				yield return Latitude;
			}
			yield return Latitude;
			if (Longitude != null)
			{
				yield return Longitude;
			}
		}

	}
}
