using APIEkobit.Options;
using BusinessEkobit.Interfaces;
using BusinessEkobit.Services;
using DataEkobit.Context;
using DataEkobit.Entities;
using DataEkobit.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.Configure<ConnectionStrings>(builder.Configuration.GetSection("ConnectionStrings"));
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("AppDbString"));

});

//builder.Services.AddScoped<IUserService<User>, UserService<User>>();
builder.Services.AddScoped<IAppDbBase<User>, AppDbBase<User>>();                //ne komentirati
builder.Services.AddScoped<UserBase>();                                         //ne komentirati
builder.Services.AddScoped<IEntityService<User>, EntityService<User>>();        //ne komentirati
builder.Services.AddScoped<IUserService, UserService>();
//builder.Services.AddScoped<IUserService, EntityService<User>>();
//builder.Services.AddScoped<IUserService, UserService>();
//builder.Services.AddScoped<IAppDbBase<User>, EntityService<User>>();          //ideja sa Stacka
//builder.Services.AddScoped<UserService>();

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


