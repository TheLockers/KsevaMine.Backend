using System;
using MediatR;
using KsevaMine.Application.DTOs;


// Класс GetBuildManifestQuery представляет собой запрос на получение манифеста сборки.
// Он содержит свойства BuildSlug, который идентифицирует сборку по ее слагу, и ManifestVersion, который указывает конкретную версию манифеста, которую нужно получить. Если ManifestVersion не указана, будет возвращена последняя версия манифеста для данной сборки. Этот класс реализует интерфейс IRequest<BuildManifestDto?>, что означает, что он ожидает получить результат в виде объекта BuildManifestDto или null, если манифест не найден.
namespace KsevaMine.Application.Builds.Queries
{
    public class GetBuildManifestQuery : IRequest<BuildManifestDto?>
    {
        public string BuildSlug { get; set; } = string.Empty;
        public int? ManifestVersion { get; set; }
    }
}
