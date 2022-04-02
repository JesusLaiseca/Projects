var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async (context) =>
{
    var msg = $"Current environment: {app.Environment.EnvironmentName}";
    await context.Response.WriteAsync(msg);
});

//app.MapGet("/", () => app.Environment.EnvironmentName);


//app.Run();
