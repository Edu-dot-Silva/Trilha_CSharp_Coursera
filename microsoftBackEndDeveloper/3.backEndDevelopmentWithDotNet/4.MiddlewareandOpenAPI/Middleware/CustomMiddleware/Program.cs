using System.Security.Cryptography.X509Certificates;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var blogs = new List<Blog>
{
    new Blog { Title = "First Blog", Body = "This is the content of the first blog." },
    new Blog { Title = "Second Blog", Body = "This is the content of the second blog." }
};

app.Use(async (context, next) =>
{
    var startTime = DateTime.UtcNow;
    await next.Invoke();
    var duration = DateTime.UtcNow - startTime;
    Console.WriteLine($"Request duration: {duration} ms");
});

app.Use(async (context, next) =>
{
    Console.WriteLine($"Incoming request: {context.Request.Method} {context.Request.Path}");
    await next.Invoke();
    Console.WriteLine($"Outgoing response: {context.Response.StatusCode}");
});

app.UseWhen(context => context.Request.Method != "GET",
    appBuilder => appBuilder.Use(async (context, next) =>
    {
        var extractedPassword = context.Request.Headers["X-Api-Key"];
        if (extractedPassword == "thisIsABadPassword")
        {
            await next.Invoke();
        }
        else
        {
            context.Response.StatusCode = 401; // Unauthorized
            await context.Response.WriteAsync("Invalid API Key");
        }
    })
);

app.MapGet("/", () => "I am root");

app.MapGet("/blogs", () =>
{
    return blogs;
});

app.MapGet("/blogs/{id}", (int id) =>
{
    if (id < 0 || id >= blogs.Count)
    {
        return Results.NotFound();
    }
    else
    {
        return Results.Ok(blogs[id]);
    }
});

app.MapPost("/blogs", (Blog blog) =>
{
    blogs.Add(blog);
    return Results.Created($"/blogs/{blogs.Count - 1}", blog);
});

app.MapDelete("/blogs/{id}", (int id) =>
{
    if (id < 0 || id >= blogs.Count)
    {
        return Results.NotFound();
    }
    else
    {
        // var blogDeleted = blogs[id];
        blogs.RemoveAt(id);
        return Results.NoContent();
    }
});

app.MapPut("/blogs/{id}", (int id, Blog blog) =>
{
    if (id < 0 || id >= blogs.Count)
    {
        return Results.NotFound();
    }
    else
    {
        blogs[id] = blog;
        return Results.Ok(blog);
    }
});

app.Run();

public class Blog
{
    public required string Title { get; set; }
    public required string Body { get; set; }
}

