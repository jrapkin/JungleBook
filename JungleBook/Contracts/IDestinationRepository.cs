using JungleBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JungleBook.Contracts
{
	public interface IDestinationRepository : IRepositoryBase<Destination>
	{
		ICollection<Destination> GetDestinationsByTripId(int tripId);
		List<Destination> GetAllDestinations();
		void CreateDestination(Destination destination);
		bool DestinationExists(Destination destination);
	}
}
