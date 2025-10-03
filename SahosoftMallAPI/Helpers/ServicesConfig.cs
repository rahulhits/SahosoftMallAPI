using BusinessService.EComm.Implementation;
using BusinessService.EComm.Interface;
using Repositories.EComm.Implementation;
using Repositories.EComm.Interface;

namespace SahosoftMallAPI.Helpers
{
	public static class ServicesConfig
	{
		public static void AddExtensionService(this IServiceCollection services)
		{
			// Dependency Injection for Repositories
			services.AddScoped<ISizeMasterRepository, SizeMasterRepository>();
			services.AddScoped<IColorMasterRepository, ColorMasterRepository>();
			services.AddScoped<IUserTypeMasterRepository, UserTypeMasterRepository>();
			services.AddScoped<ICategoryMasterRepository, CategoryMasterRepository>();
			services.AddScoped<IBrandLogoMasterRepository, BrandLogoMasterRepository>();

			// Dependency Injection for Services
			services.AddScoped<ISizeMasterService, SizeMasterService>();
			services.AddScoped<IColorMasterService, ColorMasterService>();
			services.AddScoped<IUserTypeMasterService, UserTypeMasterService>();
			services.AddScoped<ICategoryMasterService, CategoryMasterService>();
			services.AddScoped<IBrandLogoMasterService, BrandLogoMasterService>();
		}

		public static void AddConfigure(this IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment() || env.IsProduction())
			{
				app.UseRouting();
				app.UseSwagger();
				app.UseSwaggerUI(c =>
				{
					c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sahosoft Mall API v1");
				});
			}
			app.UseCors("CorsPolicy");
			app.UseStaticFiles();
		}
	}
}
