global using CQRSMediatRMovie.Core.Enums;
global using CQRSMediatRMovie.Domain.Entities.Movie;
global using Microsoft.EntityFrameworkCore;
global using MediatR;
global using CQRSMediatRMovie.Repository.Context;
global using CQRSMediatRMovie.Domain.DTOs.Requests.Movie;
global using CQRSMediatRMovie.Domain.DTOs.Responses.Movie;
global using CQRSMediatRMovie.Application.Movies.Commands.CreateMovie;
global using CQRSMediatRMovie.Application.Movies.Queries.GetMovies;
global using CQRSMediatRMovie.Application.Movies.Queries.GetMovie;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>( options => {
    options.UseNpgsql(builder.Configuration.GetConnectionString("DataContext"));
} );

builder.Services.AddMediatR(typeof(Program));

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
