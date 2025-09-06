/*
* Program.cs 
* event-list 
*
* Created by Tiago Amaral on 05/09/2025. 
* Copyright ©2024 Tiago Amaral. All rights reserved.
*/

using System.Reflection;
using Module.Eventlist.Infra.Controller;
using Module.Eventlist.Service;
using Module.Eventlist.Storage.Interface;
using Module.EventList.Service.Interface;

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
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.Run();
