using Levi9_competition.Data;
using Levi9_competition.Interfaces;
using Levi9_competition.Repos;
using Levi9_competition.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(
        options => options.UseInMemoryDatabase(builder.Configuration.GetConnectionString("MyLeviDb"))
);

builder.Services.AddHostedService<PlayerProcessor>();

builder.Services.AddScoped<IPlayerRepo, PlayerRepo>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
