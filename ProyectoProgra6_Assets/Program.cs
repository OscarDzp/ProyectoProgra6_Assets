using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProyectoProgra6_Assets.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var CnnStrBuilder = new

SqlConnectionStringBuilder(builder.Configuration.GetConnectionString("CNNSTR"));

string CnnStr = CnnStrBuilder.ConnectionString;

builder.Services.AddDbContext<Progra6Proyecto2024Context>(options => options.UseSqlServer(CnnStr));

CnnStrBuilder.Password = "progra6";

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

app.UseAuthorization();

app.MapControllers();

app.Run();
