using SqlTrainer.Postgres.Extensions;
using SqlTrainer.TestService.Infrastructure.Extensions;
using SqlTrainer.TestService.Persistence.Dtos;
using SqlTrainer.TestService.Persistence.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

var connectionString = config.GetConnectionString("Default")!;

builder.Services
    .InjectRepositories(connectionString)
    .InjectBusinessLogics();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.MigrateDatabase<Program>().Run();