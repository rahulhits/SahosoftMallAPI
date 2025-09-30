using Repositories.UserManagement.Implementation;
using Repositories.UserManagement.Interface;

namespace SahosoftMallAPI.Helpers
{
	public static class ServicesConfig
	{
		public static void AddExtensionService(this IServiceCollection services)
		{

			//Dependency Injection for Repositories
			services.AddScoped<ISizeMasterRepository, SizeMasterRepository>();
			//Dependency Injection for Services
			services.AddScoped<ISizeMasterService, SizeMasterService>();
		}

	}
}
