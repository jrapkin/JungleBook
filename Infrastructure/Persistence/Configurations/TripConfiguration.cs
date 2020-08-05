using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
	public class TripConfiguration : IEntityTypeConfiguration<Trip>
	{
		public void Configure(EntityTypeBuilder<Trip> builder)
		{
			builder.HasKey(e => e.TripId);
		}
	}
}
