/*
* Program.cs 
* event-list 
*
* Created by Tiago Amaral on 05/09/2025. 
* Copyright ©2024 Tiago Amaral. All rights reserved.
*/

using Module.Eventlist.Infra.Controller;
using Module.Eventlist.Service;
using Module.Eventlist.Storage.Interface;
using Module.EventList.Service.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Custom Module
builder.Services.AddScoped<IEventListStorage, EventListStorage>();

builder.Services.AddScoped<IEventListDeleteByIdentifierService, EventListDeleteByIdentifierService>();
builder.Services.AddScoped<IEventListFetchByIdentifierService, EventListFetchByIdentifierService>();
builder.Services.AddScoped<IEventListFetchService, EventListFetchService>();
builder.Services.AddScoped<IEventListSaveService, EventListSaveService>();

builder.Services.AddScoped<IEventListServices, EventListServices>();
builder.Services.AddScoped<EventListController>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// var summaries = new[]
// {
//     "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
// };

// app.MapGet("/weatherforecast", () => {
//     var forecast =  Enumerable.Range(1, 5).Select(index => new WeatherForecast (
//             DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//             Random.Shared.Next(-20, 55),
//             summaries[Random.Shared.Next(summaries.Length)]
//         )).ToArray();
//     return forecast;
// })
// .WithName("GetWeatherForecast")
// .WithOpenApi();

app.Run();

// record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
// {
//     public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
// }
