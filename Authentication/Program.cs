using Authentication.Models;
using Authentication.Repository.Interface;
using Authentication.Repository.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<UserDBContext>(opts =>
{
    opts.UseSqlServer(builder.Configuration.GetConnectionString("UserCon"));
});


builder.Services.AddScoped<IRepo<int, Userdetail>, UserdetailRepo>();
builder.Services.AddScoped<IRepo<int, user>, UserRepo>();
builder.Services.AddScoped<IGenerateToken, GenerateTokenService>();
builder.Services.AddScoped<IManageUser, ManageUserService>();

//builder.Services.AddCors(opts =>
//{
//    opts.AddPolicy("AngularCORS", options =>
//    {
//        options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
//    });
//});


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
