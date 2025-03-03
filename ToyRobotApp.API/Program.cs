using ToyRobotApp.API.Interfaces;
using ToyRobotApp.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Register the service
builder.Services.AddScoped<IRobotService, RobotService>();
builder.Services.AddScoped<IRobotAppService, RobotAppService>();
builder.Services.AddScoped<ITableTopService, TableTopService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
