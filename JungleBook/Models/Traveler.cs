using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace JungleBook.Models
{
	public class Traveler
	{
		public int TravelerId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string UserName { get; set; }
		public string Email { get; set; }
		[ForeignKey("ApplicationUser")]
		public string ApplicationUserId { get; set; }
		public ApplicationUser ApplicationUser { get; set; }
		public List<UserProfile> UserProfiles { get; set; }

	}
}
