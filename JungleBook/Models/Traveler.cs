using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JungleBook.Models
{
	public class Traveler
	{
		public int TravelerId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string UserName { get; set; }
		public string Email { get; set; }
		public List<UserProfile> UserProfiles { get; set; }

	}
}
