using Authentication.Api;
using Authentication.Data;
using Authentication.Data.Interfaces;
using Authentication.Models.Exceptions;
using Authentication.Services;
using Authentication.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var applicationServingPort = builder.Configuration["ServingPort"]
                             ?? throw new NotConfiguredException("ServingPort");

var dbConnectionString = builder.Configuration.GetConnectionString("DefaultConnection")
                         ?? throw new NotConfiguredException("ConnectionStrings:DefaultConnection");

builder.Services.AddDbContext<AuthDbContext>(options => options.UseMySQL(dbConnectionString));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IEncryptionService, EncryptionService>();


var app = builder.Build();

app.MapAuth();


app.Run(applicationServingPort);