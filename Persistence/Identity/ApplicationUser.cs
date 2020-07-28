using Microsoft.AspNetCore.Identity;

namespace Persistence.Identity
{
	public class ApplicationUser : IdentityUser
	{
		public string CustomTag { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
	}
}
