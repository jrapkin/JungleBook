using JungleBook.Models;
using System.Collections.Generic;

namespace JungleBook.Contracts
{
	public interface IDayActivityRepository : IRepositoryBase<DayActivity>
	{
		List<DayActivity> GetActivitiesByDay(List<Destination> destinations);
		void CreateDayActivity(DayActivity dayActivity);
	}

}
