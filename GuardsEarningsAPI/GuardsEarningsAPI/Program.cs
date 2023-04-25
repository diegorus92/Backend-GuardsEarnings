using GuardsEarnings_BL.Services;
using GuardsEarnings_DAL.Data;
using GuardsEarnings_DAL.Models;
using GuardsEarnings_DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.Extensions.Options;
using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddDbContext<Context>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("AppConnection"));

});


builder.Services.AddScoped<DbContext, Context>();

builder.Services.AddScoped<IGuardRepository, GuardRepository>();
builder.Services.AddScoped<IGuardService, GuardService>();

builder.Services.AddScoped<ITargetRepository, TargetRepository>();
builder.Services.AddScoped<ITargetService, TargetService>();   

builder.Services.AddScoped<IJourneyRepository, JourneyRepository>();
builder.Services.AddScoped<IJourneyService, JourneyService>();

builder.Services.AddScoped<IWorkRepository, WorkRepository>();
builder.Services.AddScoped<IWorkService, WorkService>();



builder.Services.AddControllers().AddJsonOptions(options =>
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles);

builder.Services.AddCors();

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

app.UseCors(c => c.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseAuthorization();

app.MapControllers();

app.Run();
