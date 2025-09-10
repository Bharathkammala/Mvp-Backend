using Microsoft.AspNetCore.Mvc;
using MVPBackend.Data;
using MVPBackend.Models;

namespace MVPBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamMembersController : ControllerBase
    {
        private readonly AppDbContext _context;
        public TeamMembersController(AppDbContext context) => _context = context;

        [HttpGet]
        public IActionResult GetTeamMembers() => Ok(_context.TeamMembers.ToList());

        [HttpPost]
        public IActionResult AddTeamMember(TeamMember member)
        {
            _context.TeamMembers.Add(member);
            _context.SaveChanges();
            return Ok(new { message = "Team member added successfully!", member });
        }

        [HttpDelete("{teamId}/{userId}")]
        public IActionResult RemoveTeamMember(int teamId, int userId)
        {
            var member = _context.TeamMembers.Find(teamId, userId);
            if (member == null) return NotFound();

            _context.TeamMembers.Remove(member);
            _context.SaveChanges();
            return Ok(new { message = "Team member removed successfully!" });
        }
    }
}
