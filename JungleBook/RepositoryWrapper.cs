using JungleBook.Contracts;
using JungleBook.Data;

namespace JungleBook
{
	public class RepositoryWrapper : IRepositoryWrapper
	{
		private ApplicationDbContext _context;
		private IAccommodationRepository _accomodation;
		private IActivityRepository _activity;
		private IAddressRepository _address;
		private IDayRepository _day;
		private IDayActivityRepository _dayActivity;
		private IDestinationRepository _destination;
		private ITravelerRepository _traveler;
		private ITripRepository _trip;
		private IUserProfileRepository _userProfile;
		public RepositoryWrapper(ApplicationDbContext context)
		{
			_context = context;
		}
		public IAccommodationRepository Accomodation
		{
			get
			{
				if (_accomodation == null)
				{
					_accomodation = new AccommodationRepository(_context);
				}
				return _accomodation;
			}
		}
		public IActivityRepository Activity
		{
			get
			{
				if (_activity == null)
				{
					_activity = new ActivityRepository(_context);
				}
				return _activity;
			}
		}
		public IAddressRepository Address
		{
			get
			{
				if (_address == null)
				{
					_address = new AddressRepository(_context);
				}
				return _address;
			}
		}
		public IDayRepository Day
		{
			get
			{
				if (_day == null)
				{
					_day = new DayRepository(_context);
				}
				return _day;
			}
		}
		public IDayActivityRepository DayActivity
		{
			get
			{
				if (_dayActivity == null)
				{
					_dayActivity = new DayActivityRepository(_context);
				}
				return _dayActivity;
			}
		}
		public IDestinationRepository Destination
		{
			get
			{
				if (_destination == null)
				{
					_destination = new DestinationRepository(_context);
				}
				return _destination;
			}
		}
		public ITravelerRepository Traveler
		{
			get
			{
				if (_traveler == null)
				{
					_traveler = new TravelerRepository(_context);
				}
				return _traveler;
			}
		}
		public ITripRepository Trip
		{
			get
			{
				if (_trip == null)
				{
					_trip = new TripRepository(_context);
				}
				return _trip;
			}
		}
		public IUserProfileRepository UserProfile
		{
			get
			{
				if (_userProfile == null)
				{
					_userProfile = new UserProfileRepository(_context);
				}
				return _userProfile;
			}
		}
		public void Save()
		{
			_context.SaveChanges();
		}
	}
}
