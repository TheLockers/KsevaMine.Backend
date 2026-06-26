using MediatR;
using KsevaMine.Application.DTOs;

namespace KsevaMine.Application.Servers.Queries.GetServerInfo
{
    public class GetServerInfoQuery : IRequest<ServerInfoDto?>
    {
        public string Name { get; set; } = string.Empty;
        public string Version { get; set; } = string.Empty;
    }
}
