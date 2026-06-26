using AutoMapper;
using KsevaMine.Application.DTOs;
using KsevaMine.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KsevaMine.Application.Servers.Queries.GetServerInfo
{
    public class GetServerInfoQueryHandler : IRequestHandler<GetServerInfoQuery, ServerInfoDto?>
    {
        public readonly IApplicationDbContext _db;
        public readonly IMapper _mapper;

        public GetServerInfoQueryHandler(IApplicationDbContext db, IMapper mapper) 
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ServerInfoDto?> Handle(
            GetServerInfoQuery request,
            CancellationToken cancellationToken)
        {
            var server = await _db.Servers
                .Include(s => s.Build)            // Подгружаем связанную сборку
                .Include(s => s.BuildVersion)     // Подгружаем версию сборки
                .FirstOrDefaultAsync(s =>
                    s.Name == request.Name &&
                    s.Build.MinecraftVersion == request.Version,
                    cancellationToken);

            if (server == null)
                return null;

            return _mapper.Map<ServerInfoDto>(server);
        }
    }
}
