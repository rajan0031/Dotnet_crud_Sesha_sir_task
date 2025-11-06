using Microsoft.AspNetCore.Mvc;
using DotNetCrudAPI.Data;
using DotNetCrudAPI.Models;




namespace DotNetCrudAPI.Controllers
{

    // this is the base api controller for user managements 
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase // inheriting the UserControlllers from the bsecontrollers .. here only json response no views 
    {
        private readonly AppDbContext _context; // create an instance of the appdbcontext for database interactions 

        public UserController(AppDbContext context) // constructor fr the user contrloer to initlize the dbcontext 
        {
            _context = context;// _context is now will be used 
        }

        [HttpPost("add")] // https verbs --> Post to add a  user in data base 
        public IActionResult AddUser([FromBody] User user) // Iaction results in return actions of the json data ..
        {
            _context.Users.Add(user);   
            _context.SaveChangesAsync();// wait for some time first save the details and then go down ..
            return Ok(new { message = "User added successfully", user });
        }

        [HttpGet("all")] // get all 
        public IActionResult GetAllUsers()
        {
            var users = _context.Users.ToList();
            return Ok(users);
        }




        [HttpGet("{id:int}")]
        public IActionResult GetUserById(int id)
        {
            var user = _context.Users.Find(id);  // find user by id 
            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                return NotFound(new { message = "User not found" });
            }
        }




        [HttpPut("update/{id:int}")] // update the user 
        public IActionResult UpdateUser(int id, [FromBody] User user)
        {
            var userDetails = _context.Users.Find(id);
            if (userDetails == null)
                return NotFound(new { message = $"User with id {id} not found." });

            userDetails.Name = user.Name;
            userDetails.Email = user.Email;
            userDetails.Password = user.Password;

            _context.SaveChangesAsync(); // wait for some time first save the details and then go down ..
            return Ok(new { message = "User updated successfully", userDetails });
        }


        [HttpDelete("delete/{id:int}")] // deletion of user entry from db , id is to unique iden..
        public IActionResult DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
                return NotFound(new { message = $"User with id {id} not found." });

            _context.Users.Remove(user);
            _context.SaveChangesAsync();// wait for some time first save the details and then go down ..

            return Ok(new { message = "User deleted successfully" });
        }


    }
}