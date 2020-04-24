using JungleBook.Contracts;
using JungleBook.Models;

namespace JungleBook.Data
{
	public class DayRepository : RepositoryBase<Day>, IDayRepository
	{
		public DayRepository(ApplicationDbContext applicationDbContext)
			: base(applicationDbContext)
		{

		}
		public void CreateDay(Day day)
		{
			Create(day);
		}
	}
}
