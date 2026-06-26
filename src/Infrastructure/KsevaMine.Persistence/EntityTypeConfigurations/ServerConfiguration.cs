using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using KsevaMine.Domain.Entities;


// Конфигурация сущности Server для Entity Framework Core, определяющая структуру таблицы и отношения между сущностями в базе данных
namespace KsevaMine.Persistence.EntityTypeConfigurations
{
    public class ServerConfiguration : IEntityTypeConfiguration<Server>
    {
        // Метод для конфигурации сущности Server
        public void Configure(EntityTypeBuilder<Server> builder) 
        {
            // Конфигурация таблицы и полей для сущности Server
            builder.HasKey(server => server.Id);        // Первичный ключ конфигурации
            builder.HasIndex(server => server.Address)  // Уникальный индекс для поля Address
                .IsUnique();                            // Указывает, что значение в поле Address должно быть уникальным, предотвращая дублирование адресов серверов в базе данных
            
            builder.Property(server => server.Address)  // Конфигурация свойства Address
                .HasMaxLength(255)                      // Устанавливает максимальную длину для поля Address, ограничивая его до 255 символов, что обеспечивает оптимальное использование пространства в базе данных и предотвращает слишком длинные адреса серверов
                .IsRequired();                          // Указывает, что поле Address является обязательным, не позволяя сохранять записи без указания адреса сервера                         
            
            builder.Property(server => server.Name)     // Конфигурация свойства Name
                .HasMaxLength(255)                      // Устанавливает максимальную длину для поля Name, ограничивая его до 255 символов, что обеспечивает оптимальное использование пространства в базе данных и предотвращает слишком длинные имена серверов
                .IsRequired();                          // Указывает, что поле Name является обязательным, не позволяя сохранять записи без указания имени сервера 
            
            builder.Property(server => server.Port)
                .HasMaxLength(5).IsRequired();

            builder.Property(server => server.Description)
                .IsRequired(false);

            // Конфигурация отношений между Server и Build, а также между Server и BuildVersion

            // Внешний ключ для Build с ограничением удаления (Restrict), чтобы предотвратить удаление связанных записей
            builder.HasOne(server => server.Build)          // Настройка связи между Server и Build
                .WithMany(server => server.Servers)         // Указывает, что один Build может быть связан с несколькими Server
                .HasForeignKey(server => server.BuildId)    // Указывает, что BuildId является внешним ключом для связи с Build
                .OnDelete(DeleteBehavior.Restrict);         // Устанавливает поведение при удалении, запрещая удаление связанных записей в Build, если они используются в Server

            // Внешний ключ для BuildVersion с ограничением удаления (SetNull), чтобы при удалении связанной записи устанавливать значение в null
            builder.HasOne(server => server.BuildVersion)           // Настройка связи между Server и BuildVersion
                .WithMany()                                         // Указывает, что один BuildVersion может быть связан с несколькими Server, но не указывает навигационное свойство для обратной связи
                .HasForeignKey(server => server.BuildVersionId)     // Указывает, что BuildVersionId является внешним ключом для связи с BuildVersion
                .IsRequired(false)                                  // Указывает, что BuildVersionId является необязательным полем, позволяя ему принимать значение null
                .OnDelete(DeleteBehavior.SetNull);                  // Устанавливает поведение при удалении, позволяя при удалении связанной записи в BuildVersion устанавливать значение BuildVersionId в null в Server
        }
    }
}
