using Application.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Identity;

namespace Infrastructure.Persistence.Data
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}
		public DbSet<Accommodation> Accommodations { get; set; }
		public DbSet<Activity> Activities { get; set; }
		public DbSet<Address> Addresses { get; set; }
		public DbSet<Day> Days { get; set; }
		public DbSet<Destination> Destinations { get; set; }
		public DbSet<Trip> Trips { get; set; }
		public DbSet<Traveler> Travelers { get; set; }
		public DbSet<UserProfile> UserProfiles { get; set; }
		public DbSet<DayActivity> DayActivities { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<DayActivity>().HasKey(d => new { d.DayId, d.ActivityId });
			modelBuilder.Entity<DayActivity>()
						.HasOne(d => d.Day)
						.WithMany(d => d.DayActivities)
						.HasForeignKey(d => d.DayId);
			modelBuilder.Entity<DayActivity>()
						.HasOne(a => a.Activity)
						.WithMany(a => a.DayActivities)
						.HasForeignKey(a => a.ActivityId);
			modelBuilder.Entity<UserProfile>().HasKey(u => new { u.TravelerId, u.TripId });
			modelBuilder.Entity<UserProfile>()
						.HasOne(u => u.Traveler)
						.WithMany(u => u.UserProfiles)
						.HasForeignKey(u => u.TravelerId);
			modelBuilder.Entity<UserProfile>()
						.HasOne(t => t.Trip)
						.WithMany(t => t.UserProfiles)
						.HasForeignKey(t => t.TripId);
			modelBuilder.Entity<Destination>()
						.HasOne(t => t.Trip)
						.WithMany(d => d.Destinations);
			modelBuilder.Entity<Day>()
						.HasOne(d => d.Destination)
						.WithMany(d => d.Days);
			modelBuilder.Entity<Address>()
						.HasData(
					 new Address
					 {
						 AddressId = 1,
						 City = "Denver",
						 State = "Colorado",
						 Country = "United States"
					 },
					new Address
					{
						AddressId = 2,
						City = "San Diego",
						State = "California",
						Country = "United States"
					},

					new Address
					{
						AddressId = 3,
						City = "Seattle",
						State = "Washington",
						Country = "United States"
					},

					new Address
					{
						AddressId = 4,
						City = "Tampa",
						State = "Florida",
						Country = "United States"
					},

					new Address
					{
						AddressId = 5,
						City = "Galway",
						Country = "Ireland"
					},

					new Address
					{
						AddressId = 6,
						City = "England",
						Country = "United Kingdom"
					}
				);
			modelBuilder.Entity<Destination>()
						.HasData(
						new Destination
						{
							DestinationId = 1,
							Name = "Denver",
							AddressId = 1
						},

						new Destination
						{
							DestinationId = 2,
							Name = "San Diego",
							AddressId = 2
						},
						new Destination
						{
							DestinationId = 3,
							Name = "Seattle",
							AddressId = 3
						},
						new Destination
						{
							DestinationId = 4,
							Name = "Tampa",
							AddressId = 4
						},
						new Destination
						{
							DestinationId = 5,
							Name = "Galway",
							AddressId = 5
						},
						new Destination
						{
							DestinationId = 6,
							Name = "England",
							AddressId = 6
						}
					);
		}
	}
}
