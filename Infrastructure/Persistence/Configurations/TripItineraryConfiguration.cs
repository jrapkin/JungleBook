using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastructure.Persistence.Configurations
{
	public class TripItineraryConfiguration : IEntityTypeConfiguration<TripItinerary>
	{
		public void Configure(EntityTypeBuilder<TripItinerary> builder)

		{
			builder.HasKey(e => e.TripItineraryId);

			builder.HasOne(e => e.Trip)
				   .WithMany(e => e.TripItineraries)
				   .HasForeignKey(e => e.TripId)
				   .OnDelete(DeleteBehavior.ClientSetNull);

		}
	}
}
