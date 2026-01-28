using System.IO.Pipelines;
using System.Security.Cryptography.X509Certificates;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IMyService, MyService>();

var app = builder.Build();

app.Use(async (context, next) =>
{
    var myService = context.RequestServices.GetRequiredService<IMyService>();
    myService.LogCreation("Handling request in middleware.");
    await next.Invoke();
});

app.Use(async (context, next) =>
{
    var myService = context.RequestServices.GetRequiredService<IMyService>();
    myService.LogCreation("Handling request in second middleware.");
    await next.Invoke();
});

app.MapGet("/", (IMyService myService) =>
{
    myService.LogCreation("Hello from the root endpoint!");
    return Results.Ok("Check the console for the service log.");
});

app.Run();

public interface IMyService
{
    void LogCreation(string message);
}

public class MyService : IMyService
{
    private readonly int _serviceId;

    public MyService()
    {
        _serviceId = new Random().Next(1, 1000);
    }

    public void LogCreation(string message)
    {
        Console.WriteLine($"Service ID: {_serviceId}, Message: {message}");
    }
}
