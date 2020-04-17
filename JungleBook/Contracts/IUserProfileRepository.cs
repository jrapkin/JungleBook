using JungleBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JungleBook.Contracts
{
	public interface IUserProfileRepository : IRepositoryBase<UserProfile>
	{
		void CreateUserProfile(UserProfile userProfile);
		List<UserProfile> GetAllTripsByTraveler(int travelerId);
	}
}
