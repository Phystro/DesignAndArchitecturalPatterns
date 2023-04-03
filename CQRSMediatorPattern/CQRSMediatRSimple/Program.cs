global using Microsoft.EntityFrameworkCore;
global using CQRSMediatRSimple.Models;
global using CQRSMediatRSimple.Data;
global using CQRSMediatRSimple.Application.Queries;
global using CQRSMediatRSimple.Application.Commands;
global using MediatR;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

builder.Services.AddDbContext<DataContext>( options => {
    options.UseNpgsql(builder.Configuration.GetConnectionString("DataContext"));
} );

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
