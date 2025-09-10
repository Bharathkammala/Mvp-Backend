namespace MVPBackend.Models
{
    public class TeamMember
    {
        public int TeamId { get; set; }
        public int UserId { get; set; }
        public string Role { get; set; } = string.Empty;
    }
}
