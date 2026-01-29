var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Root Routing path");

app.MapGet("/users/{userId}/posts/{slug}", (int userId, string slug) =>
{
    return $"User ID: {userId}, Post Slug: {slug}";
});

app.MapGet("/products/{id:int:min(0)}", (int id) =>
{
    return $"Product ID: {id}";
});

app.MapGet("/report/{year?}", (int? year = 2061) =>
{
    return $"Report Year: {year}";
});

app.MapGet("/files/{*filePath}", (string filePath) =>
{
    return $"File Path: {filePath}";
});

app.MapGet("/search", (string? query, int page = 1) =>
{
    return $"Search Query: {query}, Page: {page}";
});

app.MapGet("/store/{category}/{productId:int?}/{*extraPath}", (string category, int? productId, string? extraPath, bool inStock = true) =>
{
    return $"Category: {category}, Product ID: {productId}, Extra Path: {extraPath}, In Stock: {inStock}";
});

app.Run();