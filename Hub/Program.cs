Console.Title = "Hub";

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR();

var app = builder.Build();
app.MapHub<ChatHub>("/chatHub");
app.MapGet("/", (HttpContext context) => context.Response.WriteAsync("<h1>Hello World</h1>"));
app.UseWebSockets();

app.Run();