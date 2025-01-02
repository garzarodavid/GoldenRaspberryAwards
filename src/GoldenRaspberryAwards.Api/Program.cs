using GoldenRaspberryAwards.Application.Services;
using GoldenRaspberryAwards.Domain.Repositories;
using GoldenRaspberryAwards.Infrastructure.Data;
using GoldenRaspberryAwards.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AwardsContext>(opt => opt.UseInMemoryDatabase("AwardsDB"));
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<IProducerRepository, ProducerRepository>();
builder.Services.AddScoped<IAwardService, AwardService>();
builder.Services.AddScoped<CsvLoader>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Outsera - Golden Raspberry Awards API",
        Description = "ASP.NET Core Web API para gerenciamento de Premiações de Filmes",
        Contact = new OpenApiContact
        {
            Name = "David Garzaro",
        },
    });

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AwardsContext>();
    var csvLoader = services.GetRequiredService<CsvLoader>();
    csvLoader.LoadCsv();
}

app.Run();

public partial class Program { }