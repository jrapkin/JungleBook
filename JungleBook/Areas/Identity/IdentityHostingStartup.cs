using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(JungleBook.Areas.Identity.IdentityHostingStartup))]
namespace JungleBook.Areas.Identity
{
	public class IdentityHostingStartup : IHostingStartup
	{
		public void Configure(IWebHostBuilder builder)
		{
			builder.ConfigureServices((context, services) =>
			{
			});
		}
	}
}