namespace MVPBackend.Models
{
    public class Team
    {
        public int TeamId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
