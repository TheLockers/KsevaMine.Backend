using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using KsevaMine.Domain.Entities;


// Конфигурация сущности BuildVersion для Entity Framework Core, определяющая структуру таблицы и отношения между сущностями в базе данных
namespace KsevaMine.Persistence.EntityTypeConfigurations
{
        public class BuildVersionConfiguration : IEntityTypeConfiguration<BuildVersion>
    {
        // Метод для конфигурации сущности BuildVersion
        public void Configure(EntityTypeBuilder<BuildVersion> builder)
        {
            // Конфигурация свойств сущности BuildVersion
            builder.HasKey(buildversion => buildversion.Id);                                                            // Первичный ключ
            builder.HasIndex(buildversion => new { buildversion.BuildId, buildversion.ManifestVersion }).IsUnique();    // Уникальный индекс на сочетание BuildId и ManifestVersion


            // Связь между BuildVersion и Build (один ко многим) 
            builder.HasOne(buildversion => buildversion.Build)          // Каждая версия сборки связана с одной сборкой
                .WithMany(build => build.Versions)                      // Каждая сборка может иметь несколько версий
                .HasForeignKey(buildversion => buildversion.BuildId)    // Внешний ключ в таблице BuildVersion, указывающий на Build
                .OnDelete(DeleteBehavior.Cascade);                      // При удалении сборки удаляются все связанные версии сборки
        }
    }
}
