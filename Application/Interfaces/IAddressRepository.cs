using Domain.Models;
using System.Collections.Generic;

namespace Application.Interfaces
{
	public interface IAddressRepository : IRepositoryBase<Address>
	{
		ICollection<Address> GetAllAddresses();
		void CreateAddress(Address address);
		bool CheckIfAddressExists(Address address);
	}
}
