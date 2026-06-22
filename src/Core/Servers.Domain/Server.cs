namespace Servers.Domain
{
    internal class Server
    {
        public int Id { get; set; }
        public string Address { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int BuildId { get; set; }
        public int? BuildVersionId { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }

        public Build Build { get; set; } = null!;
        public BuildVersion? BuildVersion { get; set; }
    }
}
