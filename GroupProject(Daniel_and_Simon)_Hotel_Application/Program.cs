using Microsoft.AspNetCore.Builder;
using Amazon.Extensions.NETCore.Setup;
using Microsoft.Extensions.DependencyInjection;
using GroupProject_Daniel_and_Simon__Hotel_Application.Models;
using Microsoft.EntityFrameworkCore;
using GroupProject_Daniel_and_Simon__Hotel_Application.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<UserContext>(opt => opt.UseInMemoryDatabase("User"));
builder.Services.AddDbContext<BookingContext>(opt => opt.UseInMemoryDatabase("Booking"));

//builder.Services.AddDbContext<UserContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("HotelApiConnectionString_User")));
//builder.Services.AddDbContext<BookingContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("HotelApiConnectionString_Booking")));

builder.Services.AddScoped<IBookingRepository, BookingRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Get the AWS profile information from configuration providers
AWSOptions awsOptions = builder.Configuration.GetAWSOptions();

// Configure AWS service clients to use these credentials
builder.Services.AddDefaultAWSOptions(awsOptions);

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
