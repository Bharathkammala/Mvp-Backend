using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
namespace MVPBackend.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        [JsonIgnore]                 // won't be serialized in responses
        public string PasswordHash { get; set; } = string.Empty;

        public string Role { get; set; } = "member";
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
