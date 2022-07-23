
using Microsoft.AspNetCore.Mvc;
using Hotel.Models;
using GroupProject_Daniel_and_Simon__Hotel_Application.Models;
using Microsoft.EntityFrameworkCore;

namespace GroupProject_Daniel_and_Simon__Hotel_Application.Controllers
{
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly UserContext _UserContext;

        public UserController(UserContext userContext)
        {
            _UserContext = userContext;

        }

        //Login Page
        //[HttpGet("")]
        //public IActionResult Index()
        //{

        //    return View();
        //}

        //Login Page Validation
        //[HttpGet("validate")]
        //public async Task<IActionResult> Login(String username, String Password)
        //{
        //    User user = await _dynamoDBContext.LoadAsync<User>(username);

        //    if (user.Password.Equals(Password))
        //    {
        //        return RedirectToAction("booking");
        //    }

        //    return View(user);
        //}

        //Get All Users
        [HttpGet("Users")]
        public async Task<IActionResult> Users()
        {
            return Ok(await _UserContext.Users.ToListAsync());
        }

        //GET Create User
        //[HttpGet("create")]
        //public IActionResult CreateUser()
        //{

        //    return View();
        //}

        //POST Create User
        [HttpPost("create")]
        public async Task<IActionResult> CreateUserAsync(User user)
        {
            User newUser = new()
            {
                Id = user.Id,
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password
            };
            await _UserContext.AddAsync(newUser);
            await _UserContext.SaveChangesAsync();

            return Ok(newUser);

        }

        //GET Update User
        //[HttpGet("Update/{username}")]
        //public async Task<IActionResult> GetUSerByUsername(String username)
        //{

        //    User user = await _dynamoDBContext.LoadAsync<User>(username);

        //    return View(user);
        //}

        //Post Update User
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateUser(int id, User user)
        {
            User updateUser = await _UserContext.Users.FindAsync(id);
            if(updateUser != null)
            {
                updateUser.Username = user.Username;
                updateUser.FirstName = user.FirstName;
                updateUser.LastName = user.LastName;
                updateUser.Email = user.Email;
                updateUser.Password = user.Password;

                await _UserContext.SaveChangesAsync();
            }
            return NotFound();
        }

        //Delete User
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            User deleteUser = await _UserContext.Users.FindAsync(id);
            if (deleteUser != null)
            {
                _UserContext.Remove(deleteUser);
                await _UserContext.SaveChangesAsync();
                return Ok(deleteUser);
            }
            return NotFound();
        }
      
    }
}
