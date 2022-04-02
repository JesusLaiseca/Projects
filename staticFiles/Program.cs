var builder = WebApplication.CreateBuilder(args);
#region "Inyecion de dependencias"
builder.Services.AddDirectoryBrowser();
#endregion
var app = builder.Build();

#region "midlelware"

/*
app.UseDefaultFiles(
    new DefaultFilesOptions { DefaultFileNames = new[] {"index.html"}
});
app.UseStaticFiles();
app.UseDirectoryBrowser();
*/

app.UseFileServer(new FileServerOptions
{
    RequestPath = "/test/static",
    EnableDirectoryBrowsing = true,
    EnableDefaultFiles = true,
});


app.Run(async context =>
{
    await context.Response.WriteAsync("Hello world!");
});

#endregion

app.Run();
