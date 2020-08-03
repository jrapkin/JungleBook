namespace Application.Interfaces
{
	public interface IRepositoryWrapper
	{
		IAccommodationRepository Accomodation { get; }
		IActivityRepository Activity { get; }
		IAddressRepository Address { get; }
		IDayActivityRepository DayActivity { get; }
		IDayRepository Day { get; }
		IDestinationRepository Destination { get; }
		ITravelerRepository Traveler { get; }
		ITripRepository Trip { get; }
		IUserProfileRepository UserProfile { get; }
		void Save();
	}
}
