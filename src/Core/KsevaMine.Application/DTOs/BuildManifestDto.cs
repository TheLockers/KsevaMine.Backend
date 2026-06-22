using AutoMapper;
using KsevaMine.Application.Common.Mappings;
using KsevaMine.Domain.Entities;


namespace KsevaMine.Application.DTOs
{
    public class BuildManifestDto : IMapWith<BuildVersion>
    {
        public string BuildId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string MinecraftVersion { get; set; } = string.Empty;
        public string ModLoader { get; set; } = string.Empty;
        public int ManifestVersion { get; set; }
        public List<ManifestFileDto> Files { get; set; } = new();

        public void Mapping(Profile profile)
        {
            profile.CreateMap<BuildVersion, BuildManifestDto>()
                .ForMember(dto => dto.BuildId, opt => opt.MapFrom(version => version.Build.Slug))
                .ForMember(dto => dto.Name, opt => opt.MapFrom(version => version.Build.Name))
                .ForMember(dto => dto.MinecraftVersion, opt => opt.MapFrom(version => version.Build.MinecraftVersion))
                .ForMember(dto => dto.ModLoader, opt => opt.MapFrom(version => version.Build.ModLoader))
                .ForMember(dto => dto.ManifestVersion, opt => opt.MapFrom(version => version.ManifestVersion))
                .ForMember(dto => dto.Files, opt => opt.MapFrom(version => version.Files));
        }
    }
}
