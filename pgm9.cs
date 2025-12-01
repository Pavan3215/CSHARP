using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

interface IMessageService { string GetMessage(); }

class TransientService : IMessageService { public string GetMessage() => "Transient"; }
class ScopedService : IMessageService { public string GetMessage() => "Scoped"; }
class SingletonService : IMessageService { public string GetMessage() => "Singleton"; }

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IMessageService, TransientService>();
builder.Services.AddScoped<IMessageService, ScopedService>();
builder.Services.AddSingleton<IMessageService, SingletonService>();

var app = builder.Build();

app.MapGet("/", (IMessageService svc) => svc.GetMessage());

app.Run();
