using DotNetCrudAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args); // builder to build application , 

builder.Services.AddControllers(); // adding controllers to services collections 
builder.Services.AddSwaggerGen();


// database connection start 
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// databse connection end 

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection(); // redirect from http to https --- enable secure connections 
app.MapControllers();

app.MapGet("/", () => "hello rajan the server is running ");  // --- api testing 
app.Run();