using Microsoft.AspNetCore.Mvc;
using MVPBackend.Data;
using MVPBackend.Models;

namespace MVPBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly AppDbContext _context;
        public TasksController(AppDbContext context) => _context = context;

        [HttpGet]
        public IActionResult GetTasks() => Ok(_context.Tasks.ToList());
        [HttpPost]
        public IActionResult CreateTask(TaskItem task)
        {
            task.CreatedAt = DateTime.Now;
            task.UpdatedAt = DateTime.Now;

            _context.Tasks.Add(task);
            _context.SaveChanges();

            return Ok(task);
        }

        [HttpPut("{id}/assign/{userId}")]
        public IActionResult AssignTask(int id, int userId)
        {
            var task = _context.Tasks.Find(id);
            if (task == null) return NotFound("Task not found");

            task.AssigneeId = userId;
            task.UpdatedAt = DateTime.Now;
            _context.SaveChanges();

            return Ok(new { message = "Task assigned successfully!" });
        }
    }
}
