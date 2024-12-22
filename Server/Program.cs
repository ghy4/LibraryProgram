using Database.Services;
using Database.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System.Configuration;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using System.Security.Policy;
using Data.Models;
using AutoMapper;
using Server.Automapper;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ILibraryService, LibraryService>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped(_ => new MyDbContext(builder.Configuration.GetSection("ConnectionString").Value));
builder.Services.AddScoped<IMapper>(_ => AutoMapperConfig.GetConfiguration().CreateMapper());
builder.Services.AddSwaggerGen();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
