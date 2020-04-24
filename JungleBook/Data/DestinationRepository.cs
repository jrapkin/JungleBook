using JungleBook.Contracts;
using JungleBook.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace JungleBook.Data
{
	public class DestinationRepository : RepositoryBase<Destination>, IDestinationRepository
	{
		public DestinationRepository(ApplicationDbContext applicationDbContext)
			: base(applicationDbContext)
		{
		}
		public ICollection<Destination> GetDestinationsByTripId(int tripId)
		{
			return FindByCondition(d => d.Trip.TripId == tripId).Include(a => a.Address).ToList();
		}
		public List<Destination> GetAllDestinations()
		{
			return FindAll().Include(a => a.Address).ToList();
		}
		public void CreateDestination(Destination destination)
		{
			Create(destination);
		}
		public bool DestinationExists(Destination destination)
		{
			if (FindByCondition(d => d.Name == destination.Name).Any())
			{
				return true;
			}
			return false;
		}
	}
}
