using System;


// Класс, представляющий сборку Minecraft, содержащую информацию о версии, модификационном загрузчике и связанных серверах и версиях сборки
namespace KsevaMine.Domain.Entities
{
    public class Build
    {
        public int Id { get; set; }                                                                 //Первичный ключ сборки
        public string Slug { get; set; } = string.Empty;                                            // Уникальный идентификатор сборки, используемый в URL и API
        public string Name { get; set; } = string.Empty;                                            // Название сборки, отображаемое пользователям
        public string MinecraftVersion { get; set; } = string.Empty;                                // Версия Minecraft, для которой предназначена сборка (например, "1.20.4")
        public string ModLoader { get; set; } = string.Empty;                                       // Тип модификационного загрузчика, используемого в сборке (например, "Forge", "Fabric")
        public string Description { get; set; } = string.Empty;                                     // Краткое описание сборки, отображаемое пользователям
        public int LatestManifestVersion { get; set; }                                              // Номер последней версии манифеста, связанной с этой сборкой, используемый для отслеживания обновлений
        public DateTime CreatedAt { get; set; }                                                     // Дата и время создания сборки, используемые для сортировки и отображения информации о сборке
        public DateTime UpdatedAt { get; set; }                                                     // Дата и время последнего обновления сборки, используемые для отслеживания изменений и отображения информации о сборке


        // Навигационные свойства для связи с серверами и версиями сборки
        public ICollection<Server> Servers { get; set; } = new List<Server>();                      // Коллекция серверов, использующих эту сборку
        public ICollection<BuildVersion> BuildVersions { get; set; } = new List<BuildVersion>();    // Коллекция версий сборки, связанных с этой сборкой
    }
}
