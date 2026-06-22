using System;
using MediatR;

namespace KsevaMine.Application.Builds.Commands.CreateBuild
{
    public class CreateBuildCommand : IRequest<int>
    {
        public string Slug { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string MinecraftVersion { get; set; } = string.Empty;
        public string ModLoader { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
