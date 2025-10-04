using Authentication.Api;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();


var applicationServingPort = builder.Configuration["ServingPort"]
                             ?? throw new ArgumentNullException("Configuration:ServingPort");

app.MapAuth();

app.Run(applicationServingPort);