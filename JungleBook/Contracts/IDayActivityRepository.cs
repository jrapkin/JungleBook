using JungleBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JungleBook.Contracts
{
	public interface IDayActivityRepository : IRepositoryBase<DayActivity>
	{
		List<DayActivity> GetActivitiesByDay(List<Destination> destinations);
		void CreateDayActivity(DayActivity dayActivity);
	}
	
}
