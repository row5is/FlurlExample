using Flurl;
using Flurl.Http;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello Philly.NET");
const string baseUrl = "https://jsonplaceholder.typicode.com";

// Build a URL
var url = "https://jsonplaceholder.typicode.com:8080"
    .AppendPathSegment("posts");

Console.WriteLine("Simple URL");
Console.WriteLine("==========");
Console.WriteLine($"url: {url}");
Console.WriteLine($"Scheme: {url.Scheme}");
Console.WriteLine($"Host: {url.Host}");
Console.WriteLine($"Port: {url.Port}");
Console.WriteLine($"Query: {url.Query}");

Console.WriteLine($"Is Realative: {url.IsRelative}");
Console.WriteLine($"Is Secure: {url.IsSecureScheme}");

// Query Parameters - multiple
//url.SetQueryParams(new
//{
//    api_key = "somekey",
//    client = "philly.net",
//    sometext = "this is some text that get's encoded correctly!"
//});

//Console.WriteLine($"url: {url}");

//foreach (var (Name, Value) in url.QueryParams)
//{
//    Console.WriteLine($"Name - {Name}, Value - {Value}");
//}

// Query Parameters single array
//url.SetQueryParam("paging", new[] { 1, 2, 3 });

//foreach (var (Name, Value) in url.QueryParams)
//{
//    Console.WriteLine($"Name - {Name}, Value - {Value}");
//}

//Console.WriteLine(url);

// flurl http
//var result = await baseUrl.AppendPathSegment("posts").GetAsync();

//Console.WriteLine($"Status Code: {result.StatusCode}");
//Console.WriteLine();
//Console.WriteLine("Headers");
//Console.WriteLine("=======");
//foreach (var (Name, Value) in result.Headers)
//{
//    Console.WriteLine($"{Name} - {Value}");
//}

//Console.WriteLine(await result.GetStringAsync());

//var posts = await result.GetJsonAsync<IEnumerable<Post>>();

//foreach (var post in posts)
//{
//    Console.WriteLine(post.Title);
//}

// Get Json Async
//var todos = await baseUrl
//    .AppendPathSegment("users")
//    .AppendPathSegment("1")
//    .AppendPathSegment("todos")
//    .GetJsonAsync<IEnumerable<Todo>>();

//foreach (var todo in todos)
//{
//    Console.WriteLine($"Id: {todo.Id} \nTitle: {todo.Title}, {todo.Completed}");
//}

// Patch
//var patchResult = await baseUrl
//    .AppendPathSegment("todos")
//    .AppendPathSegment("1")
//    .PatchJsonAsync(new { completed = "True" });

//Console.WriteLine(patchResult.StatusCode);

//Console.WriteLine(await patchResult.GetStringAsync());


class Post
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }

}

class Todo
{
    public int Id { get; set; }
    public int UserId { set; get; }
    public string Title { set; get; }
    public bool Completed { get; set; }
}