var builder = WebApplication.CreateBuilder(args);

// Adiciona suporte a endpoints e Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configura Swagger apenas em desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Lista em memória simulando um banco de dados
var blogs = new List<Blog>
{
    new Blog { Id = 1, Title = "First Blog", Body = "This is the content of the first blog." },
    new Blog { Id = 2, Title = "Second Blog", Body = "This is the content of the second blog." }
};

// Middleware de logging simples
app.Use(async (context, next) =>
{
    Console.WriteLine($"[{DateTime.Now}] {context.Request.Method} {context.Request.Path}");
    await next.Invoke();
    Console.WriteLine($"[{DateTime.Now}] Response: {context.Response.StatusCode}");
});

// Lista em memória simulando um banco de dados para usuários
var users = new List<User>
{
    new User { Id = 1, Name = "Alice", Email = "alice@email.com" },
    new User { Id = 2, Name = "Bob", Email = "bob@email.com" }
};

app.MapGet("/", () => "API de Blogs - Root");

app.MapGet("/blogs", () => Results.Ok(blogs));

app.MapGet("/blogs/{id}", (int id) =>
{
    var blog = blogs.FirstOrDefault(b => b.Id == id);
    return blog is null ? Results.NotFound() : Results.Ok(blog);
});

app.MapPost("/blogs", (Blog blog) =>
{
    if (string.IsNullOrWhiteSpace(blog.Title) || string.IsNullOrWhiteSpace(blog.Body))
        return Results.BadRequest("Title and Body are required.");

    blog.Id = blogs.Any() ? blogs.Max(b => b.Id) + 1 : 1;
    blogs.Add(blog);

    return Results.Created($"/blogs/{blog.Id}", blog);
});

app.MapPut("/blogs/{id}", (int id, Blog updatedBlog) =>
{
    var blog = blogs.FirstOrDefault(b => b.Id == id);
    if (blog is null) return Results.NotFound();

    blog.Title = updatedBlog.Title;
    blog.Body = updatedBlog.Body;

    return Results.Ok(blog);
});

app.MapDelete("/blogs/{id}", (int id) =>
{
    var blog = blogs.FirstOrDefault(b => b.Id == id);
    if (blog is null) return Results.NotFound();

    blogs.Remove(blog);
    return Results.NoContent();
});

// CRUD para usuários
app.MapGet("/users", () => Results.Ok(users));

app.MapGet("/users/{id}", (int id) =>
{
    var user = users.FirstOrDefault(u => u.Id == id);
    return user is null ? Results.NotFound() : Results.Ok(user);
});

app.MapPost("/users", (User user) =>
{
    if (string.IsNullOrWhiteSpace(user.Name) || string.IsNullOrWhiteSpace(user.Email))
        return Results.BadRequest("Name and Email are required.");
    if (users.Any(u => u.Email == user.Email))
        return Results.BadRequest("Email already exists.");
    user.Id = users.Any() ? users.Max(u => u.Id) + 1 : 1;
    users.Add(user);
    return Results.Created($"/users/{user.Id}", user);
});

app.MapPut("/users/{id}", (int id, User updatedUser) =>
{
    var user = users.FirstOrDefault(u => u.Id == id);
    if (user is null) return Results.NotFound();
    if (string.IsNullOrWhiteSpace(updatedUser.Name) || string.IsNullOrWhiteSpace(updatedUser.Email))
        return Results.BadRequest("Name and Email are required.");
    if (users.Any(u => u.Email == updatedUser.Email && u.Id != id))
        return Results.BadRequest("Email already exists.");
    user.Name = updatedUser.Name;
    user.Email = updatedUser.Email;
    return Results.Ok(user);
});

app.MapDelete("/users/{id}", (int id) =>
{
    var user = users.FirstOrDefault(u => u.Id == id);
    if (user is null) return Results.NotFound();
    users.Remove(user);
    return Results.NoContent();
});

app.Run();

public class Blog
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Body { get; set; }
}

public class User
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
}
