using Authentication.Api;
using Authentication.Services;
using Authentication.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IEncryptionService, EncryptionService>();


var app = builder.Build();


var applicationServingPort = builder.Configuration["ServingPort"]
                             ?? throw new ArgumentNullException("Configuration:ServingPort");

app.MapAuth();

app.Run(applicationServingPort);