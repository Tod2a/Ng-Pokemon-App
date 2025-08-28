using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using ng_pokemon.API.Middlewares;
using ng_pokemon.Application;
using ng_pokemon.Infrastructure;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
var storagePath = builder.Configuration["Storage:PhysicalPath"];
var storageRequestPath = "/storage";
string? connectionString = builder.Configuration.GetConnectionString("ng-pokemon");

if (string.IsNullOrEmpty(connectionString))
    throw new InvalidOperationException("Missing ng-pokemon in appsettings.json");
if (string.IsNullOrEmpty(storagePath))
    throw new InvalidOperationException("Missing storage path in appsettings.json");

builder.Host.UseSerilog((context, configuration) =>
            configuration.ReadFrom.Configuration(context.Configuration));

// Add services to the container.
builder.Services.AddInfrastructure(connectionString);
builder.Services.AddApplication();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(storagePath),
    RequestPath = new PathString(storageRequestPath)
});

app.UseHttpsRedirection();

app.UseSerilogRequestLogging();

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.Run();
