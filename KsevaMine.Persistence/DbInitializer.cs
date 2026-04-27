// DbInitializer.cs
namespace KsevaMine.Persistence
{
    // Класс DbInitializer используется для инициализации базы данных при запуске приложения. Метод Initialize проверяет, существует ли база данных, и если нет, то создает ее. Это полезно для обеспечения того, что база данных готова к использованию при первом запуске приложения.
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated(); // Создание базы данных, если она еще не существует
        }
    }
}
