using JungleBook.Models;
using JungleBook.Contracts;
using System.Collections.Generic;
using System.Linq;

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
		public List<UserProfile> GetAllTripsByTraveler(int travelerId)
		{
			return FindByCondition(t => t.TravelerId == travelerId).ToList();
		}
	}
}
