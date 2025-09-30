using Microsoft.CodeAnalysis.CSharp.Syntax;
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
		public static void AddConfigure(this IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment()|| env.IsProduction())
			{
				app.UseRouting();
				app.UseSwagger();
				app.UseSwaggerUI(c =>
				{
					c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sahosoft Mall API v1");
					c.RoutePrefix = string.Empty;
				});
				
			}
			app.UseCors("CorsPolicy");
			app.UseStaticFiles();
		}
	}
}
