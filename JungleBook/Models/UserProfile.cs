using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

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
