using Ocelot.DependencyInjection;
using Ocelot.Infrastructure;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOcelot();

var app = builder.Build();


await app.UseOcelot();

app.Run();
