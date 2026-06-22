using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KsevaMine.Domain.Entities;


// Интерфейс IApplicationDbContext определяет контракт для взаимодействия с базой данных, предоставляя доступ к DbSet для каждой сущности и метод для сохранения изменений в базе данных
namespace KsevaMine.Application.Interfaces
{
    // IApplicationDbContext - это интерфейс, который определяет контракт для взаимодействия с базой данных в приложении. Он предоставляет свойства DbSet для каждой сущности (Build, BuildFile, BuildVersion, Server) и метод SaveChangesAsync для сохранения изменений в базе данных асинхронно.
    public interface IApplicationDbContext
    {
        DbSet<Build> Builds { get; set; }                   // Свойство DbSet для доступа к сущности Build, представляющей сборки Minecraft, и позволяющее выполнять операции CRUD (создание, чтение, обновление, удаление) над данными сборок в базе данных
        DbSet<BuildFile> BuildFiles { get; set; }           // Свойство DbSet для доступа к сущности BuildFile, представляющей файлы сборок, и позволяющее выполнять операции CRUD над данными файлов сборок в базе данных
        DbSet<BuildVersion> BuildVersions { get; set; }     // Свойство DbSet для доступа к сущности BuildVersion, представляющей версии сборок, и позволяющее выполнять операции CRUD над данными версий сборок в базе данных
        DbSet<Server> Servers { get; set; }                 // Свойство DbSet для доступа к сущности Server, представляющей серверы, и позволяющее выполнять операции CRUD над данными серверов в базе данных


        // Метод SaveChangesAsync сохраняет все изменения, внесенные в сущности, отслеживаемые контекстом базы данных, в базе данных асинхронно. Он принимает CancellationToken для возможности отмены операции сохранения, если это необходимо.
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
