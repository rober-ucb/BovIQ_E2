using BovIQ.Persistence;
using BovIQ_E2.API.Extensions;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services
    .AddDatabaseProvider(builder.Configuration)
    .AddRepositories();

builder.Services.AddApplicationServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.ApplyMigrations();
    app.MapScalarApiReference(options => options.Servers = []);
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
