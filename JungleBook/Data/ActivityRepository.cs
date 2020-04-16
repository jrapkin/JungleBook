using JungleBook.Contracts;
using JungleBook.Models;

namespace JungleBook.Data
{
	public class ActivityRepository : RepositoryBase<Activity>, IActivityRepository
	{
		public ActivityRepository(ApplicationDbContext applicationDbContext)
			: base(applicationDbContext)
		{

		}
	}
}
