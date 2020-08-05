using Domain.ValueObjects;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
	public class Accommodation
	{
		public int AccommodationId { get; set; }
		public string Name { get; set; }
		public Address Address { get; set; }
	}
}
