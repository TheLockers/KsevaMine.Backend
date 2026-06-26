using AutoMapper;
using KsevaMine.Application.Common.Mappings;
using KsevaMine.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace KsevaMine.Application.DTOs
{
    public class ServerInfoDto : IMapWith<Server>
    {
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int Port { get; set; }
        public string MinecraftVersion { get; set; } = string.Empty;
        public string BuildSlug { get; set; } = string.Empty;
        public int? BuildVersion { get; set; }
        public string ManifestHash { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public string Description { get; set; } = string.Empty;

        // Настройка AutoMapper
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Server, ServerInfoDto>()
        .ForMember(dto => dto.MinecraftVersion,
            opt => opt.MapFrom(s => s.Build != null ? s.Build.MinecraftVersion : "unknown"))
        .ForMember(dto => dto.BuildSlug,
            opt => opt.MapFrom(s => s.Build != null ? s.Build.Slug : ""))
        .ForMember(dto => dto.BuildVersion,
            opt => opt.MapFrom(s => s.BuildVersion != null ? (int?)s.BuildVersion.ManifestVersion : null))
        .ForMember(dto => dto.ManifestHash,
            opt => opt.MapFrom(s => "12345678")); // Пока заглушка
        }
    }
}
