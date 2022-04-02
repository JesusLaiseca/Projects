var builder = WebApplication.CreateBuilder(args);

var currentEnvironmentName = builder.Environment.EnvironmentName;

/* Asigna el servidor web HttpSys y un puerto
builder.WebHost.UseHttpSys(options =>
{
    options.UrlPrefixes.Add("http://localhost:5005");
});
*/

/*
// Registra los servicios de Entity Framework Core para SQLite
builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseSqlite(connectionString: "...")
);

// Registra los servicios de autenticación basada en cookies
builder.Services.AddAuthentication().AddCookie();

// Registra los servicios del framework MVC
builder.Services.AddControllersWithViews();
*/

/*
if (builder.Environment.IsDevelopment())
{
    builder.Services.AddSingleton<ISender, FakeSender>();
}
else
{
    builder.Services.AddSingleton<ISender, EmailSender>();
}
*/
var app = builder.Build();


//app.MapGet("/", () => "Hello World!");

/*AmbiguousMatchException: HTTP: GET /
app.MapGet("/", (HttpContext context) =>
{
    var name = (string)context.Request.Query["name"] ?? "Unknown user";
    return $"Hello, {name}!";
});
*/

app.MapGet("/", () =>
    app.Environment.IsDevelopment()
        ? "Hello developer!"
        : "Hello user!"
);


/*Para nombres de entorno ajenos a la convención, podemos usar IsEnvironment() de la siguiente forma:
var app = builder.Build();
if (app.Environment.IsEnvironment("Home"))
{
    app.MapGet("/home", () => "This is only available for Home environment");
}
*/


//endpoints adicional
app.MapGet("/time", (HttpContext context) =>
{
    return $"{DateTime.Now.ToString()}!";

});

//endpoints adicional
app.MapGet("/sum", (HttpContext context) =>
{
    var valorA = (string)context.Request.Query["a"] ?? "0";
    var valorB = (string)context.Request.Query["b"] ?? "0";
    var a = int.Parse(valorA);
    var b = int.Parse(valorB);

    if (string.Concat(a, b).Length > 0)
    {
        var c = a + b;
        return $"{a}+{b}={c}";
    }
    else
    {
        return $"debes imputar sum?a=valor&b=valor";
    }

});

app.MapGet("/environment", () => app.Environment.EnvironmentName);



app.Run();
