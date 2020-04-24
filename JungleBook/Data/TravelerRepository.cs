using JungleBook.Contracts;
using JungleBook.Models;
using System.Collections.Generic;
using System.Linq;

namespace JungleBook.Data
{
	public class TravelerRepository : RepositoryBase<Traveler>, ITravelerRepository
	{
		public TravelerRepository(ApplicationDbContext applicationDbContext)
			: base(applicationDbContext)
		{
		}
		public void CreateTraveler(Traveler traveler) => Create(traveler);
		public ICollection<Traveler> GetTravelBuddiesByTripId(int tripId)
		{
			return FindAll().Where(t => t.UserProfiles.Any(up => up.TripId == tripId)).ToList();
		}
		public Traveler GetTravelerByUserId(string userId)
		{
			return FindByCondition(t => t.ApplicationUserId == userId).FirstOrDefault();
		}
	}
}
