var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


//app.MapGet("/", () => "Hello World!");

app.MapGet("/", (HttpContext context) =>
{
    var name = (string)context.Request.Query["name"] ?? "Unknown user";
    return $"Hello, {name}!";
});

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

app.Run();
