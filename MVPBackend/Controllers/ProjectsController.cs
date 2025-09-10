using Microsoft.AspNetCore.Mvc;
using MVPBackend.Data;
using MVPBackend.Models;

namespace MVPBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ProjectsController(AppDbContext context) => _context = context;

        [HttpGet]
        public IActionResult GetProjects() => Ok(_context.Projects.ToList());

        [HttpGet("{id}")]
        public IActionResult GetProject(int id)
        {
            var project = _context.Projects.Find(id);
            if (project == null) return NotFound();
            return Ok(project);
        }

        [HttpPost]
        public IActionResult CreateProject(Project project)
        {
            project.CreatedAt = DateTime.Now;
            _context.Projects.Add(project);
            _context.SaveChanges();
            return Ok(new { message = "Project created successfully!", project });
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProject(int id, Project updated)
        {
            var project = _context.Projects.Find(id);
            if (project == null) return NotFound();

            project.Name = updated.Name;
            project.Description = updated.Description;
            project.CreatedBy = updated.CreatedBy;
            _context.SaveChanges();

            return Ok(new { message = "Project updated successfully!", project });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProject(int id)
        {
            var project = _context.Projects.Find(id);
            if (project == null) return NotFound();

            _context.Projects.Remove(project);
            _context.SaveChanges();
            return Ok(new { message = "Project deleted successfully!" });
        }
    }
}
