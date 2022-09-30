using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDbCrudApp.DataAccessLayer.Repository;
using MongoDbCrudApp.Models;
using MongoDbCrudApp.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<StudentDbSettings>(
    builder.Configuration.GetSection(nameof(StudentDbSettings)));

builder.Services.AddSingleton<IStudentDbSettings>(sp =>
    sp.GetRequiredService<IOptions<StudentDbSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(s =>
    new MongoClient(builder.Configuration.GetSection("StudentDbSettings:ConnectionString").Value));

builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IStudentService, StudentService>();
// Add services to the container.

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
