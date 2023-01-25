using Common;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "simple rebus scenario", Version = "v1" }); });
builder.Services.AddRebusService(builder.Configuration);
var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EntryPointAPI v1"));
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.Run();
