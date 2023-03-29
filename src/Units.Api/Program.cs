using Microsoft.AspNetCore;
using Units.Api;

var builder = WebHost
    .CreateDefaultBuilder(args)
    .UseStartup<Startup>();

var app = builder.Build();

app.Run();