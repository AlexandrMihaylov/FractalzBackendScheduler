using System.Text;
using System.Text.Json.Serialization;
using FractalzBackendScheduler.Application;
using FractalzBackendScheduler.Infrastructure.Database;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

string _specificCorsName = "CustomCorsPolicy";
var services = builder.Services;
var Configuration = builder.Configuration;

services.AddCors(options =>
{
    options.AddPolicy(
        name: _specificCorsName,
        builder =>
        {
            builder
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

services.AddControllers()
    .AddJsonOptions(o =>
    {
        o.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
    });

services.AddApplication();
services.AddInfrastructureDataBase(Configuration);

#region Swagger Configuration

services.AddSwaggerGen(swagger =>
{
    //This is to generate the Default UI of Swagger Documentation
    swagger.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "FractalzBackendScheduler", 
        Description = "ASP.NET Core 5.0 Web API"
    });
});
#endregion

#region Authentication


#endregion

var app = builder.Build();


app.UseExceptionHandler("/Error");
app.UseHsts();


app.UseWebSockets(new WebSocketOptions
{
    KeepAliveInterval = TimeSpan.FromSeconds(30),
});

app.UseCors(_specificCorsName);
            
app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.UseSwagger();

app.UseSwaggerUI();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "FractalzBackendScheduler");
    c.RoutePrefix = string.Empty;
});

app.Run();