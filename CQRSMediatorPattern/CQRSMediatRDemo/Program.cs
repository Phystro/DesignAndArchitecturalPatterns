global using Microsoft.EntityFrameworkCore;
global using CQRSMediatRDemo.Models;
global using MediatR;
global using CQRSMediatRDemo.Repositories;
global using CQRSMediatRDemo.Data;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DataContext>( options => {
    options.UseNpgsql(builder.Configuration.GetConnectionString("DataContext"));
} );

builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

builder.Services.AddScoped<IStudentRepository, StudentRepository>();

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

app.Run();
