using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<string> books = new() { "Book1", "Book2" };

app.MapGet("/books", () => books);
app.MapPost("/books/{name}", (string name) => { books.Add(name); return "Added"; });
app.MapPut("/books/{index}/{name}", (int index, string name) => { books[index] = name; return "Updated"; });
app.MapDelete("/books/{index}", (int index) => { books.RemoveAt(index); return "Deleted"; });

app.Run();
