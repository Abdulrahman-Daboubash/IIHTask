using Application.Service.UserSrvice;
using Application.Service.UserSrvice.UserDTO;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class usersController : ControllerBase
    {
        private IUserService _userService;
        public usersController (IUserService userService)
        {

            _userService = userService;
        }
        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _userService.GetUsers();
            return Ok(users);
        }
        [HttpGet("{id}")]
        public IActionResult GetUser(Guid id)
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
        [HttpPost]
        public IActionResult AddUser ([FromBody]InsertUserDto input)
        {
            _userService.InsertUser(input);
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult EditUser (Guid id,[FromBody]InsertUserDto input)
        {
            _userService.UpdateUser(id,input);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteUser (Guid id)
        {
            _userService.DeleteUser(id);
            return Ok();
        }
    }
}
