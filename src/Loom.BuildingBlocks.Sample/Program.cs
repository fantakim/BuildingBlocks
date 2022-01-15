using Loom.BuildingBlocks.Mediatr.Autofac;
using Loom.BuildingBlocks.Sample;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddUserSecrets<Program>(optional: true);

var apiInfo = ApiInfo.From(builder.Configuration);

// Add services to the container.
builder.Services
    .AddSingleton(apiInfo)
    .AddLoomMvc()
    .AddLoomPermissiveCors()
    .AddLoomIdentity(ApiInfo.Instance)
    .AddLoomSwagger(ApiInfo.Instance)
    .ConvertToAutofac(MediatrModule.Create(ApiInfo.Instance.ApplicationAssembly));

builder.Services
    .AddIdentityServer()
    .AddDeveloperSigningCredential();

var app = builder.Build();

app.UseLoomPermissiveCors();
app.UseAuthentication();
app.UseLoomSwagger(apiInfo);
app.UseIdentityServer();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
       new WeatherForecast
       (
           DateTime.Now.AddDays(index),
           Random.Shared.Next(-20, 55),
           summaries[Random.Shared.Next(summaries.Length)]
       ))
        .ToArray();
    return forecast;
});

app.Run();

internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}