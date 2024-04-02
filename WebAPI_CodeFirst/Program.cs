using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using System;
using WebAPI_CodeFirst.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Register Library Service to use it with Dependency Injection in Controllers
//builder.Services.AddTransient<ILibraryService, LibraryService>();
// Register database
builder.Services.AddDbContext<StudentDbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("StringConnection")));

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

app.Run();
