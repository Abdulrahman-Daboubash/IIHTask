using Application.Service;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        public UserController (IUserService userService)
        {

            _userService = userService;
        }
        [HttpGet("GetUsers")]
        public IActionResult GetUsers()
        {
            var users = _userService.GetUsers();
            return Ok(users);
        }
        [HttpGet("GetUser/{id}")]
        public IActionResult GetUser(int id)
        {
            var user = _userService.GetUser(id);
            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost("AddUser")]
        public IActionResult AddUser ([FromBody]User input)
        {
            _userService.InsertUser(input);
            return Ok();
        }
        [HttpPut("UpdateUser/{id}")]
        public IActionResult EditUser (int id,[FromBody]User input)
        {
            _userService.UpdateUser(id,input);
            return Ok();
        }
        [HttpDelete("DeleteUser/{id}")]
        public IActionResult DeleteUser (int id)
        {
            _userService.DeleteUser(id);
            return Ok();
        }
    }
}
