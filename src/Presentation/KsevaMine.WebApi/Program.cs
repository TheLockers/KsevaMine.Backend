using KsevaMine.Application.DTOs;
using KsevaMine.Application.Interfaces;
using KsevaMine.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(ServerInfoDto).Assembly));

builder.Services.AddAutoMapper(cfg =>
    cfg.AddMaps(typeof(ServerInfoDto).Assembly));

// Строка подключения SQLite
var connectionString = builder.Configuration["DbConnection"];
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));

// Регистрация интерфейса IApplicationDbContext
builder.Services.AddScoped<IApplicationDbContext>(provider =>
    provider.GetService<ApplicationDbContext>()!);

var app = builder.Build();

// Автосоздание базы и таблиц при первом запуске
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.EnsureCreated();

}

app.UseRouting();
app.MapControllers();
app.Run();