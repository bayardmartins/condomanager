global using CondoManager.Data;
global using Microsoft.EntityFrameworkCore;
global using CondoManager.Repositories;
global using CondoManager.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddTransient<IUnitOfWork,UnitOfWork>();
builder.Services.AddTransient<IApartamentRepository,ApartmentRepository>();
builder.Services.AddTransient<ICondoBlockRepository,CondoBlockRepository>();
builder.Services.AddTransient<ICondoRespository,CondoRepository>();
builder.Services.AddTransient<IResidentRepository,ResidentRepository>();

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
