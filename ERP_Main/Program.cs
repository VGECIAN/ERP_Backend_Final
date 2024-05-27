using ERP_Common;
using ERP_Data.Repository;
using ERP_Domain;
using ERP_Main.Infrastructure;
using ERP_Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// add cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder => builder.SetIsOriginAllowed(origin => true)
                                                    .AllowAnyMethod()
                                                    .AllowAnyHeader()
                                                    .AllowCredentials());
});

ConfigItems.Configuration = builder.Configuration;

builder.Services.AddEntityFrameworkNpgsql().AddDbContext<ERPDbContext>(opt => opt.UseNpgsql(ConfigItems.ConnectionString));
builder.Services.AddProjectRepositories().AddProjectServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
