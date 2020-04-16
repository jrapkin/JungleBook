using JungleBook.Models;
using JungleBook.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JungleBook.Data
{
	public class UserProfileRepository : RepositoryBase<UserProfile>, IUserProfileRepository
	{
		public UserProfileRepository(ApplicationDbContext applicationDbContext)
			: base(applicationDbContext)
		{

		}
		public void CreateUserProfile(UserProfile userProfile)
		{
			Create(userProfile);
		}
	}
}
