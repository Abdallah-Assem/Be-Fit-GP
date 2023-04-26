using BeFit_API.CloudinarySettings;
using BeFit_API.Data;
using CloudinaryDotNet;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<WebsiteDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("BeFitDb"));
});
builder.Services.AddTransient<IPhoto, Photo>();
builder.Services.AddEndpointsApiExplorer();
// Get the Cloudinary configuration from the appsettings.json file
var cloudinaryConfig = builder.Configuration.GetSection("CloudinarySettings").Get<CloudinarySettings>();

// Configure Cloudinary
Account cloudinaryAccount = new Account(
    cloudinaryConfig.CloudName,
    cloudinaryConfig.ApiKey,
    cloudinaryConfig.ApiSecret
);
Cloudinary cloudinary = new Cloudinary(cloudinaryAccount);

// Add Cloudinary to the services container
builder.Services.AddSingleton(cloudinary);
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
