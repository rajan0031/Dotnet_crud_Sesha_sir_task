using Microsoft.AspNetCore.Mvc;
using DotNetCrudAPI.Data;
using DotNetCrudAPI.Models;




namespace DotNetCrudAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("add")]
        public IActionResult AddUser([FromBody] User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return Ok(new { message = "User added successfully", user });
        }

        [HttpGet("all")]
        public IActionResult GetAllUsers()
        {
            var users = _context.Users.ToList();
            return Ok(users);
        }

        


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _context.Users.FindAsync(id);
            return user is null ? NotFound() : Ok(user);
        }




        [HttpPut("update/{id:int}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] User user)
        {
            var userDetails = await _context.Users.FindAsync(id);
            if (userDetails is null)
                return NotFound(new { message = $"User with id {id} not found." });

            userDetails.Name = user.Name;
            userDetails.Email = user.Email;
            userDetails.Password = user.Password;

            await _context.SaveChangesAsync();
            return Ok(new { message = "User updated successfully", userDetails });
        }


        [HttpDelete("delete/{id:int}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user is null)
                return NotFound(new { message = $"User with id {id} not found." });

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return Ok(new { message = "User deleted successfully" });
        }


    }
}