using System.Net.Http;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapPost("/auto", (Person personFromClient) =>
{
    return TypedResults.Ok($"Received person: {personFromClient.UserName}, Age: {personFromClient.UserAge}");
});

app.MapPost("/json", async (HttpContent context) =>
{
    var person = await context.Request.ReadFromJsonAsync<Person>();
    return TypedResults.Ok($"Received person: {person.Result.UserName}, Age: {person.Result.UserAge}");
});


app.Run();

public class Person
{
    required public string UserName { get; set; }
    public int? UserAge { get; set; }
}

