/*
* Program.cs 
* event-list 
*
* Created by Tiago Amaral on 05/09/2025. 
* Copyright ©2024 Tiago Amaral. All rights reserved.
*/

using System.Reflection;
using Microsoft.EntityFrameworkCore;

using event_list.modules.eventlist.infra;
using event_list.modules.eventlist.storage;
using event_list.modules.eventlist.services;
using event_list.shared.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen( c => {
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

// Removendo CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});

// Custom Module
builder.Services.AddDbContext<EventListDbContext>(options =>
    options.UseInMemoryDatabase("EventListDb"));

builder.Services.AddScoped<EventListDbContext>();
builder.Services.AddScoped<IEventListStorage, EventListStorage>();
builder.Services.AddScoped<IEventListDeleteByIdentifierService, EventListDeleteByIdentifierService>();
builder.Services.AddScoped<IEventListFetchByIdentifierService, EventListFetchByIdentifierService>();
builder.Services.AddScoped<IEventListFetchService, EventListFetchService>();
builder.Services.AddScoped<IEventListSaveService, EventListSaveService>();

builder.Services.AddScoped<IEventListServices, EventListServices>();
builder.Services.AddScoped<EventListController>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseCors("AllowAll");
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<CustomHeaderResponse>();
app.UseMiddleware<ExceptionMiddleware>();
app.MapControllers();
app.UseHttpsRedirection();
app.Run();
