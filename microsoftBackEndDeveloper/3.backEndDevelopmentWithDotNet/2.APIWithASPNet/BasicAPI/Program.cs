var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Root path");
app.MapGet("/downloads", () => "Downloads");
app.MapPut("/", () => "PUT Root path");
app.MapDelete("/", () => "DELETE Root path");
app.MapPost("/", () => "POST Root path");

app.Run();
