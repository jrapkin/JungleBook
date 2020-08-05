using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastructure.Persistence.Configurations
{
	public class AccommodationConfiguration : IEntityTypeConfiguration<Accommodation>
	{
		public void Configure(EntityTypeBuilder<Accommodation> builder)
		{
			builder.HasKey(e => e.AccommodationId);
			builder.Property(e => e.Name)
				.HasColumnName("Name");

			builder.OwnsOne(e => e.Address);
		}
	}
}
