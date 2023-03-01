using APi.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

//Configure Context to Sql Server Database 
var connectionString = builder.Configuration.GetConnectionString("connection"); //untuk mendapat connection string yang ada di appsettings.json 
builder.Services.AddDbContext<MyContext>(options => options.UseSqlServer(connectionString)); //untuk mendaftarkan MyContext.cs ke Sql Server 

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
