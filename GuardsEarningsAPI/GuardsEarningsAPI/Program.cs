using GuardsEarnings_BL.Services;
using GuardsEarnings_DAL.Data;
using GuardsEarnings_DAL.Models;
using GuardsEarnings_DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<Context>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("AppConnection"));
});
builder.Services.AddScoped<DbContext, Context>();

builder.Services.AddScoped<IRepository<Guard>, GuardRepository>();
builder.Services.AddScoped<IGuardService, GuardService>();

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
