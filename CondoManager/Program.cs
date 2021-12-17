global using CondoManager.Data;
global using Microsoft.EntityFrameworkCore;
global using CondoManager.Repositories;
global using CondoManager.Models;

using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using CondoManager.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddTransient<IUnitOfWork,UnitOfWork>();
builder.Services.AddTransient<IApartmentRepository,ApartmentRepository>();
builder.Services.AddTransient<IBlockRepository,BlockRepository>();
builder.Services.AddTransient<ICondoRepository,CondoRepository>();
builder.Services.AddTransient<IResidentRepository,ResidentRepository>();
builder.Services.AddTransient<IUserRepository,UserRepository>();

var root = Directory.GetCurrentDirectory();
var dotenv = Path.Combine(root, ".env");
EnvService.Load(dotenv);

string key = Environment.GetEnvironmentVariable("SECRET_KEY");

builder.Services.AddAuthentication(x => 
    {
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(x => 
    {
        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
            ValidateIssuer = false,
            ValidateAudience = false
        };   
    });


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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
