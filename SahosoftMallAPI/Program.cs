var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

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

//app.MapGet("/", () => "Hello World!");
app.UseCors("CorsPolicy");
app.MapControllers();

app.Run();
