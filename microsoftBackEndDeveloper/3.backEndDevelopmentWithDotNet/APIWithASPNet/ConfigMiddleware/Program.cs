var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpLogging((o)=>{});
var app = builder.Build();

app.UseHttpLogging();
app.Use(async (context, next) =>
{
    Console.WriteLine("Logic before calling the next middleware");
    await next.Invoke();
    Console.WriteLine("Logic after calling the next middleware");
});

app.MapGet("/", () => "Hello World!");
app.MapGet("/hello", () => "this is the Hello route");

app.Run();
