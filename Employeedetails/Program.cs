//using Employeedetails.Data;
using DinkToPdf;
using DinkToPdf.Contracts;
using Employeedetails.Models;
using Employeedetails.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Cross orgin resourse sharing
#region CORS Config
builder.Services.AddCors(option => option.AddPolicy("QosteqEmployee",x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));
builder.Services.AddScoped<PdfGenerator>();
#endregion
//Data base connection
#region Database Config
var connectionString = builder.Configuration.GetConnectionString("DBconnection");
builder.Services.AddDbContext<QosteqEmployeeContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
#endregion
//Pdf Generator
#region Pdf Config
builder.Services.AddSingleton(typeof(IConverter),new SynchronizedConverter(new PdfTools()));
#endregion

builder.Services.AddControllersWithViews();

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

app.UseCors("QosteqEmployee"); //connect the CORS sharing

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
