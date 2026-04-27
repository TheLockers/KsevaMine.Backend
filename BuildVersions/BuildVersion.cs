using System;

namespace BuildVersion.Domain
{
    internal class BuildVersion
    {
        public int Id { get; set; }
        public int BuildId { get; set; }
        public int ManifestVersion { get; set; }
        public string Changelog { get; set; } = null!;
        public DateTime CreatedAt { get; set; }

        public Build Build { get; set; } = null!;
    }
}
