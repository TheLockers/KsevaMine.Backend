using AutoMapper;
using KsevaMine.Application.DTOs;
using KsevaMine.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;


// Класс GetBuildManifestQueryHandler обрабатывает запрос на получение манифеста сборки. Он использует интерфейс IApplicationDbContext для доступа к данным о сборках и манифестах в базе данных. Метод Handle извлекает сборку по ее слагу, чтобы узнать последнюю версию манифеста, а затем извлекает соответствующий манифест и возвращает его в виде DTO. Если сборка или манифест не найдены, возвращается null.
namespace KsevaMine.Application.Builds.Queries
{
    // Класс GetBuildManifestQueryHandler обрабатывает запрос на получение манифеста сборки. Он использует интерфейс IApplicationDbContext для доступа к данным о сборках и манифестах в базе данных. Метод Handle извлекает сборку по ее слагу, чтобы узнать последнюю версию манифеста, а затем извлекает соответствующий манифест и возвращает его в виде DTO. Если сборка или манифест не найдены, возвращается null.
    public class GetBuildManifestQueryHandler : IRequestHandler<GetBuildManifestQuery, BuildManifestDto?>
    {
        // Поле _db представляет собой экземпляр интерфейса IApplicationDbContext, который используется для доступа к данным о сборках и манифестах в базе данных. Этот интерфейс позволяет абстрагироваться от конкретной реализации базы данных и обеспечивает удобный способ взаимодействия с данными.
        private readonly IApplicationDbContext _db;
        // Поле _mapper представляет собой экземпляр интерфейса IMapper, который используется для автоматического преобразования сущностей из базы данных в DTO (Data Transfer Objects) и обратно. Это позволяет упростить код и избежать ручного маппинга между различными слоями приложения.
        private readonly IMapper _mapper;

        // Конструктор класса GetBuildManifestQueryHandler принимает в качестве параметра интерфейс IApplicationDbContext, который используется для доступа к данным о сборках и манифестах в базе данных. Этот интерфейс позволяет абстрагироваться от конкретной реализации базы данных и обеспечивает удобный способ взаимодействия с данными.
        public GetBuildManifestQueryHandler(IApplicationDbContext db, IMapper mapper)
        {
            _db = db; // Инициализация поля _db, которое будет использоваться для доступа к данным о сборках и манифестах в базе данных.
            _mapper = mapper; // Инициализация поля _mapper, которое будет использоваться для автоматического преобразования сущностей из базы данных в DTO.
        }

        // Метод Handle обрабатывает запрос на получение манифеста сборки. Он сначала получает сборку по ее слагу, чтобы узнать последнюю версию манифеста. Затем он извлекает соответствующий манифест и возвращает его в виде DTO. Если сборка или манифест не найдены, возвращается null.
        public async Task<BuildManifestDto?> Handle(
            GetBuildManifestQuery request, 
            CancellationToken cancellationToken)
        {
            var build = await _db.Builds.FirstOrDefaultAsync(build => build.Slug == request.BuildSlug, cancellationToken); // Необходимо получить Build, чтобы узнать LatestManifestVersion

            if (build == null)
            {
                return null; // Если сборка не найдена, возвращаем null
            }

            var targetVersion = request.ManifestVersion ?? build.LatestManifestVersion; // Если версия манифеста не указана в запросе, используем последнюю версию из сборки

            // Извлекаем манифест для указанной версии. Включаем связанные файлы манифеста, чтобы они были доступны в DTO.
            var version = await _db.BuildVersions
                .Where(version => version.BuildId == build.Id && version.ManifestVersion == targetVersion)
                .Include(version => version.Build) // Включаем связанные данные о сборке, если они нужны для DTO
                .Include(version => version.Files) // Включаем связанные файлы манифеста
                .FirstOrDefaultAsync(cancellationToken); 

            if (version == null)
            {
                return null; // Если манифест не найден, возвращаем null
            }
            
            return _mapper.Map<BuildManifestDto>(version); // Преобразуем сущность BuildVersion в DTO и возвращаем его
        }
    }
}
