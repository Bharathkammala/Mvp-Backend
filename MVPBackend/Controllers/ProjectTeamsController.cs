using Microsoft.AspNetCore.Mvc;
using MVPBackend.Data;
using MVPBackend.Models;

namespace MVPBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectTeamsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ProjectTeamsController(AppDbContext context) => _context = context;

        [HttpGet]
        public IActionResult GetProjectTeams() => Ok(_context.ProjectTeams.ToList());

        [HttpPost]
        public IActionResult AddProjectTeam(ProjectTeam projectTeam)
        {
            _context.ProjectTeams.Add(projectTeam);
            _context.SaveChanges();
            return Ok(new { message = "Team assigned to project successfully!", projectTeam });
        }

        [HttpDelete("{projectId}/{teamId}")]
        public IActionResult RemoveProjectTeam(int projectId, int teamId)
        {
            var pt = _context.ProjectTeams.Find(projectId, teamId);
            if (pt == null) return NotFound();

            _context.ProjectTeams.Remove(pt);
            _context.SaveChanges();
            return Ok(new { message = "Team removed from project successfully!" });
        }
    }
}
