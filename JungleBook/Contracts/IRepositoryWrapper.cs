using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JungleBook.Contracts
{
	public interface IRepositoryWrapper
	{
		IAccommodationRepository Accomodation { get; }
		IActivityRepository Activity { get; }
		IAddressRepository Address { get; }
		IDayRepository Day { get; }
		IDestinationRepository Destination { get; }
		ITripRepository Trip { get; }
		void Save();
	}
}
