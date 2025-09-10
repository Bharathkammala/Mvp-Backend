using Microsoft.AspNetCore.Mvc;
using MVPBackend.Data;
using MVPBackend.Models;

namespace MVPBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;
        public UsersController(AppDbContext context) => _context = context;

        [HttpGet]
        public IActionResult GetUsers() => Ok(_context.Users.ToList());

        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPost]
        public IActionResult CreateUser(User user)
        {
            user.CreatedAt = DateTime.Now;
            _context.Users.Add(user);
            _context.SaveChanges();
            return Ok(new { message = "User created successfully!", user });
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, User updated)
        {
            var user = _context.Users.Find(id);
            if (user == null) return NotFound();

            user.Name = updated.Name;
            user.Email = updated.Email;
            user.PasswordHash = updated.PasswordHash;
            user.Role = updated.Role;
            _context.SaveChanges();

            return Ok(new { message = "User updated successfully!", user });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null) return NotFound();

            _context.Users.Remove(user);
            _context.SaveChanges();
            return Ok(new { message = "User deleted successfully!" });
        }
    }
}
