using Microsoft.EntityFrameworkCore;
using OpenIddictClientCredentialServer.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Add EF services
var connString = builder.Configuration.GetConnectionString("DefaultConection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlite(connString);

    options.UseOpenIddict();
});

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
