using SqlTrainer.Postgres.Extensions;
using SqlTrainer.Presentation.Extensions;
using SqlTrainer.UserService.Infrastructure.Extensions;
using SqlTrainer.UserService.Persistence.Dtos;
using SqlTrainer.UserService.Persistence.Extensions;

var builder = WebApplication.CreateBuilder(args);

var config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

var connectionString = config.GetConnectionString("Default")!;
var jwtSecretKey = config.GetValue<string>("Jwt:SecretKey")!;

builder.Services
    .InjectRepositories(connectionString)
    .InjectBusinessLogics(jwtSecretKey)
    .ConfigureModelStateErrorsBehavior();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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