using System.Collections.Concurrent;
using System.Net.Http;
using System.Reflection.Metadata;
using BlogApi;

var httpClient = new HttpClient();
var apiBaseUrl = "http://localhost:5022";

var client = new BlogApiClient(apiBaseUrl, httpClient);

// o método retorna uma lista
var blogs = await client.BlogsAllAsync();

foreach (var blogItem in blogs)
{
    Console.WriteLine($"Title: {blogItem.Title}");
    Console.WriteLine($"Body: {blogItem.Body}");
    Console.WriteLine("-----");
}

// namespace APIClient
// {
//     internal class Program
//     {
//         static async Task Main(string[] args)
//         {
//             var generator = new SwaggerClientGenerator();
//             await generator.GenerateClientAsync();
//         }
//     }
// }


// // See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

// //API Running: http:localhost:5022

// var httpClient = new HttpClient();
// var apiBaseUrl = "http://localhost:5022";

// var httpResults = await httpClient.GetAsync($"{apiBaseUrl}/blogs");

// if (!httpResults.IsSuccessStatusCode)
// {
//     Console.WriteLine($"Error: {httpResults.StatusCode}");
//     return;
// }

// var blogStream = await httpResults.Content.ReadAsStreamAsync();

// var options = new System.Text.Json.JsonSerializerOptions
// {
//     PropertyNameCaseInsensitive = true
// };

// var blogs = await System.Text.Json.JsonSerializer.DeserializeAsync<List<Blog>>(blogStream, options);

// if (blogs != null)
// {
//     foreach (var blog in blogs)
//     {
//         Console.WriteLine($"Title: {blog.Title}");
//         Console.WriteLine($"Body: {blog.Body}");
//         Console.WriteLine("-----");
//     }
// }

// class Blog
// {
//     public required string Title { get; set; }
//     public required string Body { get; set; }
// }