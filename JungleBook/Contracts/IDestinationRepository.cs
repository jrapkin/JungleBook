using JungleBook.Models;
using System.Collections.Generic;

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
