using System.Collections.Generic;

namespace Domain.Models
{
	public class Traveler
	{		
		public Traveler()
		{
			TravelerTrips = new HashSet<TravelerTrip>();
		}
		public int TravelerId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string UserName { get; set; }
		public string Email { get; set; }
		public string ApplicationUserId { get; set; }
		public virtual ICollection<TravelerTrip> TravelerTrips { get; private set; }

	}
}
