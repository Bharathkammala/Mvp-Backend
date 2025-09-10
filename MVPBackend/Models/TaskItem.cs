using System.ComponentModel.DataAnnotations;

namespace MVPBackend.Models
{
    public class TaskItem
    {
        [Key]
        public int TaskId { get; set; }   // Primary Key
        public int ProjectId { get; set; }
        public int? AssigneeId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string Status { get; set; } = "todo";
        public string Priority { get; set; } = "medium";
        public int EstimatedHours { get; set; } = 0;
        public int CompletedHours { get; set; } = 0;
        public DateTime CreatedAt { get; set; } = DateTime.Now;  
        public DateTime UpdatedAt { get; set; } = DateTime.Now;  
    }
}
