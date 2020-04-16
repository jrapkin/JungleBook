using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace JungleBook.Models
{
	public class UserProfile
	{
		[ForeignKey("IdentityUser")]
		public int IdentityUserId { get; set; }
		public IdentityUser IdentityUser { get; set; }
		[ForeignKey("Trip")]
		public int TripId { get; set; }
		public Trip Trip { get; set; }
	}
}
