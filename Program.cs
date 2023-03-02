using APi.Context;
using APi.Repositories.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

//Configure Context to Sql Server Database 
var connectionString = builder.Configuration.GetConnectionString("connection"); //untuk mendapat connection string yang ada di appsettings.json 
builder.Services.AddDbContext<MyContext>(options => options.UseSqlServer(connectionString)); //untuk mendaftarkan MyContext.cs ke Sql Server 

// Configure Session
//builder.Services.AddSession(options =>
//{
//    options.IdleTimeout = TimeSpan.FromSeconds(10);
//});

builder.Services.AddScoped<UniversityRepository>();
builder.Services.AddScoped<EducationRepository>();
builder.Services.AddScoped<EmployeeRepository>();
builder.Services.AddScoped<AccountRepository>();
builder.Services.AddScoped<ProfilingRepository>();
builder.Services.AddScoped<AccountRoleRepository>();
builder.Services.AddScoped<RoleRepository>();

// Configure JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            //Usually, this is application base url
            ValidateAudience = false,   //validasi client nya, audience didapat dari appseting.json, dijadikan true jika ada services nya
                                        //ValidAudience = builder.Configuration["JWT:Audience"],

            // If the JWT is created using web service, then this could be the consumer URL
            ValidateIssuer = false,     //didapat dari appsettings.json 
            //ValidIssuer = builder.Configuration["JWT:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"])),
            ValidateLifetime = true,    //
            ClockSkew = TimeSpan.Zero
        };
    });

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

//app.UseSession();

//app.Use(async (context, next) =>
//{
//    var jwtoken = context.Session.GetString("jwtoken");
//    if (!string.IsNullOrEmpty(jwtoken))
//    {
//        context.Request.Headers.Add("Authorization", "Bearer " + jwtoken);
//    }
//    await next();
//});

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
