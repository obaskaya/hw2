using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using WebApi.DBOperations;
using Microsoft.Extensions.Configuration;
using System;
<<<<<<< Updated upstream
=======
using System.Reflection;
using AutoMapper;
using CarRentWebApi.Middlewares;
using WebApi.Services;
>>>>>>> Stashed changes

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<BookStoreDbContext>(options => options.UseInMemoryDatabase(databaseName: "BookStoreDB"));
<<<<<<< Updated upstream
=======
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddSingleton<ILoggerService, ConsoleLogger>();
>>>>>>> Stashed changes

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


var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;

DataGenerator.Initialize(services);

app.UseCustomExceptionMiddle();


app.MapControllers();

app.Run();

