using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Oreders.API.Dtos;
using Oreders.API.Models;
namespace Oreders.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UserController : ControllerBase
    {
        private readonly DataContext _context;

        public UserController(DataContext context)
        {
            _context = context;
        }
        // GET api/User
        // [AllowAnonymous]
        [HttpGet("user")]
        public async Task<IActionResult> GetUser()
        {
            var users = await (from u in _context.Users select new { u.Id, u.UserName, u.Role }).ToListAsync();
            return Ok(users);
        }
        // PUT api/User/5
        [HttpPost("Update")]
        public void UpdateUser(UserDto user)
        {
            var getuser = _context.Users.Find(user.id);
            getuser.Role = user.role;
            getuser.UserName = user.userName;
            _context.SaveChanges();
        }

        // DELETE api/Delete
        [HttpPost("Delete")]
        public async Task<IActionResult>  DeleteUser(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
        
            var deuser = await (from u in _context.Users where u.Id == id select u).FirstOrDefaultAsync();
            _context.Users.Remove(deuser);
            _context.SaveChanges();
            return Ok(200);
        }
    }
}
