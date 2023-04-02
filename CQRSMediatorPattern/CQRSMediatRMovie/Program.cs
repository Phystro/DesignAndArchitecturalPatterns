global using CQRSMediatRMovie.Core.Enums;
global using CQRSMediatRMovie.Domain.Entities.Movie;
global using Microsoft.EntityFrameworkCore;
global using CQRSMediatRMovie.Repository.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
