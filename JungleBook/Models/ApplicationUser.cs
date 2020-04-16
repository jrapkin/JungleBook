using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace JungleBook.Models
{
	public class ApplicationUser : IdentityUser
	{
		public string CustomTag { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
	}
}
