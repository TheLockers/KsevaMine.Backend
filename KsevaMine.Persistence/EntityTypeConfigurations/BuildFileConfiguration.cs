using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using KsevaMine.Domain.Entities;


// Конфигурация сущности BuildFile для Entity Framework Core, определяющая структуру таблицы и отношения между сущностями в базе данных
namespace KsevaMine.Persistence.EntityTypeConfigurations
{
    public class BuildFileConfiguration : IEntityTypeConfiguration<BuildFile>
    {
        // Метод для конфигурации сущности BuildFile
        public void Configure(EntityTypeBuilder<BuildFile> builder)
        {
            // Настройка свойств сущности BuildFile
            builder.HasKey(buildfile => buildfile.Id);              // Первичный ключ

            builder.Property(buildfile => buildfile.SHA256)         // Настройка свойства SHA256
                .HasMaxLength(64)                                   // Максимальная длина для SHA256 (64 символа)
                .IsRequired();                                      // Обязательное поле

            builder.Property(buildfile => buildfile.Path)           // Настройка свойства Path
                .HasMaxLength(500)                                  // Максимальная длина для пути к файлу (можно настроить по необходимости)
                .IsRequired();                                      // Обязательное поле


            // Настройка связи между BuildFile и BuildVersion
            builder.HasOne(buildfile => buildfile.Version)          // Связь с BuildVersion
                .WithMany(buildversion => buildversion.Files)       // Один BuildVersion может иметь много BuildFile
                .HasForeignKey(buildfile => buildfile.VersionId)    // Внешний ключ в BuildFile, указывающий на BuildVersion
                .OnDelete(DeleteBehavior.Cascade);                  // При удалении BuildVersion удалять связанные BuildFile
        }
    }
}
