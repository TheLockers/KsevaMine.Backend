using Microsoft.EntityFrameworkCore;
using KsevaMine.Application.Interfaces;
using KsevaMine.Domain.Entities;
using KsevaMine.Persistence.EntityTypeConfigurations;


// Класс ApplicationDbContext представляет собой контекст базы данных для приложения, который наследуется от DbContext и реализует интерфейс IApplicationDbContext. Он содержит DbSet для каждой сущности (Build, BuildFile, BuildVersion, Server) и метод SaveChangesAsync для сохранения изменений в базе данных асинхронно. В методе OnModelCreating выполняется конфигурация сущностей с помощью классов конфигурации (BuildConfiguration, BuildFileConfiguration, BuildVersionConfiguration, ServerConfiguration), которые определяют структуру таблиц и отношения между сущностями в базе данных.
namespace KsevaMine.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<Build> Builds { get; set; }
        public DbSet<BuildFile> BuildFiles { get; set; }
        public DbSet<BuildVersion> BuildVersions { get; set; }
        public DbSet<Server> Servers { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new BuildConfiguration());              // Применение конфигурации для сущности Build
            builder.ApplyConfiguration(new BuildFileConfiguration());          // Применение конфигурации для сущности BuildFile
            builder.ApplyConfiguration(new BuildVersionConfiguration());       // Применение конфигурации для сущности BuildVersion
            builder.ApplyConfiguration(new ServerConfiguration());             // Применение конфигурации для сущности Server
            base.OnModelCreating(builder);
        }


    }
}
