using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
	public class TravelerTripConfiguration : IEntityTypeConfiguration<TravelerTrip>
	{
		public void Configure(EntityTypeBuilder<TravelerTrip> builder)
		{

			builder.HasKey(e => new { e.TravelerId, e.TripId })
				.IsClustered(false);

			builder.Property(e => e.TravelerId).HasColumnName("TravelerId");

			builder.Property(e => e.TripId).HasColumnName("TripId");

			builder.HasOne(u => u.Traveler)
						.WithMany(u => u.TravelerTrips)
						.HasForeignKey(u => u.TravelerId)
						.OnDelete(DeleteBehavior.ClientSetNull);

			builder.HasOne(t => t.Trip)
						.WithMany(t => t.TravelerTrips)
						.HasForeignKey(t => t.TripId)
						.OnDelete(DeleteBehavior.ClientSetNull);
		}
	}
}
