using BusinessEkobit.Interfaces;
using BusinessEkobit.Services;
using DataEkobit.Context;
using DataEkobit.Entities;
using DataEkobit.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("AppDbString"));

});


builder.Services.AddScoped<IAppDbBase<User>, AppDbBase<User>>();
builder.Services.AddScoped<IAppDbBase<Country>, AppDbBase<Country>>();
builder.Services.AddScoped<IAppDbBase<Group>, AppDbBase<Group>>();
builder.Services.AddScoped<IAppDbBase<UserGroup>, AppDbBase<UserGroup>>();
builder.Services.AddScoped<IUserBase, UserBase>();
builder.Services.AddScoped<ICountryBase, CountryBase>();
builder.Services.AddScoped<IGroupBase, GroupBase>();
builder.Services.AddScoped<IUserGroupBase, UserGroupBase>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICountryService, CountryService>();
builder.Services.AddScoped<IGroupService, GroupService>();
builder.Services.AddScoped<IUserGroupService, UserGroupService>();

//builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


