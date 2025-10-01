using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.UserManagement.Implementation;
using Repositories.UserManagement.Interface;
using SahosoftMallAPI.Helpers;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
	c.SwaggerDoc("v1", new()
	{
		Title = "Sahosoft Mall API",
		Version = "v1",
		Description = "API for Sahosoft Mall Application",
		TermsOfService = new Uri("https://sahosofttech.com/terms"),
		Contact = new()
		{
			Name = "Sahosoft Tech Support",
			Email = "support@sahosoft.com",
			Url = new Uri("https://sahosofttech.com/contact")
		},
		License = new()
		{
			Name = "Use under LICX",
			Url = new Uri("https://sahosofttech.com/license")
		}
	});
});
var connectionString  = builder.Configuration.GetConnectionString("SqlDBConnection");
builder.Services.AddDbContext<ECommDBContext>(options =>
{
	options.UseSqlServer(connectionString);
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

ServicesConfig.AddExtensionService(builder.Services);

////Dependency Injection for Repositories
//builder.Services.AddScoped< ISizeMasterRepository ,SizeMasterRepository >();
////Dependency Injection for Services
//builder.Services.AddScoped<ISizeMasterService, SizeMasterService>();

builder.Services.AddCors(Options =>
{
	Options.AddPolicy("CorsPolicy", policy =>
	{
		policy.AllowAnyOrigin()
			  .AllowAnyMethod()
			  .AllowAnyHeader();
	});
});
var app = builder.Build();

ServicesConfig.AddConfigure(app, app.Environment);

//app.MapGet("/", () => "Hello World!");
//app.UseCors("CorsPolicy");
//app.UseSwagger();
//app.UseSwaggerUI(c =>
//{
//	c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sahosoft Mall API v1");
//	c.RoutePrefix = string.Empty;
//});
//app.UseStaticFiles();
app.MapControllers();

app.Run();
