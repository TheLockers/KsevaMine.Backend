using System;

namespace Servers.Domain
{
    internal class Build
    {
        public int Id { get; set; } //Первичный ключ сборки
        public string Slug { get; set; } = string.Empty; //Уникальный идентификатор сборки, используемый в URL и API
        public string Name { get; set; } = string.Empty;
        public string MinecraftVersion { get; set; } = string.Empty;
        public string ModLoader { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int LastManifestVersion { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdatedAt { get; set; }
    }
}
