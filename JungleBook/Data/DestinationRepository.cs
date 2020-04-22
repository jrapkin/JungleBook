using JungleBook.Contracts;
using JungleBook.Models;
using System.Collections.Generic;
using System.Linq;

namespace JungleBook.Data
{
	public class DestinationRepository : RepositoryBase<Destination>, IDestinationRepository
	{
		public DestinationRepository(ApplicationDbContext applicationDbContext)
			:base(applicationDbContext)
		{	
		}
		public List<Destination> GetAllDestinations()
		{
			return FindAll().ToList();
		}
		public void CreateDestination (Destination destination)
		{
			Create(destination);
		}
	}
}
