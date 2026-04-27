using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using KsevaMine.Domain.Entities;


// Конфигурация сущности BuildConfiguration для Entity Framework Core, определяющая структуру таблицы и отношения между сущностями в базе данных
namespace KsevaMine.Persistence.EntityTypeConfigurations
{
    public class BuildConfiguration : IEntityTypeConfiguration<Build>
    {
        // Метод Configure используется для настройки сущности BuildConfiguration, определяя ее свойства, ключи, индексы и отношения с другими сущностями в базе данных
        public void Configure(EntityTypeBuilder<Build> builder)
        {
            // Конфигурация для сущности BuildConfiguration
            builder.HasKey(build => build.Id);                  // Установка первичного ключа для сущности BuildConfiguration

            builder.HasIndex(build => build.Slug)               // Создание уникального индекса для свойства Slug, обеспечивающего уникальность значений в этом столбце
                .IsUnique();                                    // Установка свойства Slug как уникального, что означает, что значения в этом столбце должны быть уникальными и не могут повторяться в базе данных

            builder.Property(build => build.Slug)               // Настройка свойства Slug, определяющая его тип данных, максимальную длину и обязательность
                .HasMaxLength(255)                              // Установка максимальной длины для свойства Slug, что означает, что значения в этом столбце не могут превышать 255 символов
                .IsRequired();                                  // Установка свойства Slug как обязательного, что означает, что это поле не может быть null в базе данных

            builder.Property(build => build.Name)               // Настройка свойства Name, определяющая его тип данных, максимальную длину и обязательность
                .HasMaxLength(255)                              // Установка максимальной длины для свойства Name, что означает, что значения в этом столбце не могут превышать 255 символов
                .IsRequired();                                  // Установка свойства Name как обязательного, что означает, что это поле не может быть null в базе данных

            builder.Property(build => build.MinecraftVersion)   // Настройка свойства MinecraftVersion, определяющая его тип данных и максимальную длину
                .HasMaxLength(50);                              // Установка максимальной длины для свойства MinecraftVersion, что означает, что значения в этом столбце не могут превышать 50 символов

            builder.Property(build => build.ModLoader)          // Настройка свойства ModLoader, определяющая его тип данных и максимальную длину
                .HasMaxLength(50);                              // Установка максимальной длины для свойства ModLoader, что означает, что значения в этом столбце не могут превышать 50 символов
        }
    }
}
