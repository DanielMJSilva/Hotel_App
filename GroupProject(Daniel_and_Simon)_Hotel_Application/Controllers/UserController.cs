using Amazon.DynamoDBv2.DataModel;
using Microsoft.AspNetCore.Mvc;
using Amazon;
using System.Net;
using Amazon.DynamoDBv2.DocumentModel;
using Hotel.Models;

namespace GroupProject_Daniel_and_Simon__Hotel_Application.Controllers
{
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IDynamoDBContext _dynamoDBContext;

        public UserController(IDynamoDBContext dynamoDBContext)
        {
            _dynamoDBContext = dynamoDBContext;

        }

        //Login Page
        [HttpGet("")]
        public IActionResult Index()
        {
            //IEnumerable<User> user = await _dynamoDBContext.ScanAsync<User>(default).GetRemainingAsync();
            return View();
        }

        //Login Page
        [HttpPost]
        public async Task<IActionResult> CreateUser()
        {
            IEnumerable<User> user = await _dynamoDBContext.ScanAsync<User>(default).GetRemainingAsync();
            return View(user);
        }

    }
}
