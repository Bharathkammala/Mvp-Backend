using Microsoft.AspNetCore.Mvc;
using MVPBackend.Data;
using MVPBackend.Models;

namespace MVPBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public TeamsController(AppDbContext context) => _context = context;

        [HttpGet]
        public IActionResult GetTeams() => Ok(_context.Teams.ToList());

        [HttpGet("{id}")]
        public IActionResult GetTeam(int id)
        {
            var team = _context.Teams.Find(id);
            if (team == null) return NotFound();
            return Ok(team);
        }

        [HttpPost]
        public IActionResult CreateTeam(Team team)
        {
            team.CreatedAt = DateTime.Now;
            _context.Teams.Add(team);
            _context.SaveChanges();
            return Ok(new { message = "Team created successfully!", team });
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTeam(int id, Team updated)
        {
            var team = _context.Teams.Find(id);
            if (team == null) return NotFound();

            team.Name = updated.Name;
            team.Description = updated.Description;
            _context.SaveChanges();

            return Ok(new { message = "Team updated successfully!", team });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTeam(int id)
        {
            var team = _context.Teams.Find(id);
            if (team == null) return NotFound();

            _context.Teams.Remove(team);
            _context.SaveChanges();
            return Ok(new { message = "Team deleted successfully!" });
        }
    }
}
