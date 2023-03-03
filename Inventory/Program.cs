using Common;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls(urls: "http://localhost:5002");
// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "simple rebus scenario", Version = "v1" }); });
builder.Services.AddRebusService(builder.Configuration);
builder.Services.AddHttpClient();
var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Inventory Api v1"));
app.UseStaticFiles();
app.MapControllers();
app.UseRouting();

app.UseAuthorization();
app.Run();
