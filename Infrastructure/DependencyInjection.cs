using Application.Interfaces;
using Infrastructure.Identity;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Data;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Infrastructure
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<ApplicationDbContext>(options =>
			options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

			services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());

			services.AddDefaultIdentity<ApplicationUser>()
				.AddEntityFrameworkStores<ApplicationDbContext>()
				.AddDefaultUI()
				.AddDefaultTokenProviders();

			services.AddScoped<ClaimsPrincipal>(s => s.GetService<IHttpContextAccessor>().HttpContext.User);


			services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
			services.AddScoped<IWeatherRequest, WeatherService>();
			services.AddScoped<ISearchRequest, Eventful>();
			services.AddScoped<IGoogleServices, GoogleServices>();
			services.AddScoped<IHikingProject, HikingProject>();

			return services;
		}
	}
}
