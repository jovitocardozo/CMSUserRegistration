using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserRegistrationAPI.Models;

namespace UserRegistrationAPI.Controllers
{
    [ApiController]
    [Route("api/Users")]
    public class UsersController : Controller
    {
        //private IUserRepository _userRepository;

        private readonly ApiContext apiContext;

        public UsersController(ApiContext apiContext)
        {
            this.apiContext = apiContext;
        }
        //public UsersController(IUserRepository userRepository)
        //{
        //    _userRepository = userRepository;
        //}

        [HttpPost]
        public async Task<IActionResult> AddUser(string newUserName)
        {
            var result = apiContext.AddUser(newUserName);
            //var result = _userRepository.Create(newUserName);

            return Ok(result);
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<User> users = apiContext.GetUsers();
            //List<User> users = _userRepository.Get();
            return Ok(users);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(int userId, string newName)
        {
            List<User> users = apiContext.ModifyUser(userId, newName);
            //List<User> users = _userRepository.Update(userId, newName);
            return Ok(users);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            List<User> users = apiContext.DeleteUser(userId);
            //List<User> users = _userRepository.Delete(userId);
            return Ok(users);
        }
    }
}
