using Microsoft.EntityFrameworkCore;
using midAssignment.Entities;
using midAssignment.Services;
using midAssignment.Models;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IBookService,BookService>();
builder.Services.AddDbContext<LibraryContext>(options =>
    options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors((options) =>
            {
                options.AddPolicy("My Apllication", (builder) =>
                {
                    builder.WithOrigins("https://localhost:7281")
                    .AllowCredentials();
                });
            });
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
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(Directory.GetCurrentDirectory(), "Photos")),
    RequestPath = "/Photos"
});

app.Run();
