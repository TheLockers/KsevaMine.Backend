var builder = WebApplication.CreateBuilder(args);

// 🔵 Добавь эти две строки:
builder.Services.AddControllers();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

// 🔵 Добавь эту строку:
app.MapControllers();

app.Run();