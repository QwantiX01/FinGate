using Authentication.Api;
using Authentication.Data;
using Authentication.Data.Interfaces;
using Authentication.Services;
using Authentication.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Реєстрація всіх сервісів
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IEncryptionService, EncryptionService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserCredentialsService, UserCredentialsService>();

var app = builder.Build();

var applicationServingPort = builder.Configuration["ServingPort"]
                             ?? throw new ArgumentNullException("Configuration:ServingPort");

app.MapAuth();

app.Run(applicationServingPort);