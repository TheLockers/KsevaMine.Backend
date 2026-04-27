using AutoMapper;
using KsevaMine.Application.Common.Mappings;
using KsevaMine.Domain.Entities;

namespace KsevaMine.Application.DTOs
{
    public class ManifestFileDto : IMapWith<BuildFile>
    {
        public string Path { get; set; } = string.Empty;
        public string Sha256 { get; set; } = string.Empty;
        public long Size { get; set; }
        public bool Required { get; set; }
        public bool DeltaAvailable { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<BuildFile, ManifestFileDto>();
        }
    }
}