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
            if (!string.IsNullOrEmpty(newUserName))
            {
                var result = apiContext.AddUser(newUserName);
                //var result = _userRepository.Create(newUserName);
                if (result.Count > 3)
                    return Ok(result);
                else
                    return Ok("Duplicate user! Enter a different user name");
            }
            else
                return Ok("User name is required!"); 
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
            if (userId!=0 && !string.IsNullOrEmpty(newName))
            {
                List<User> users = apiContext.ModifyUser(userId, newName);
                //List<User> users = _userRepository.Update(userId, newName);
                return Ok(users);
            }
            return Ok("User id cannot be empty or zero and user name cannot be passed as empty or null!");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            if (userId > 0)
            {
                List<User> users = apiContext.DeleteUser(userId);
                //List<User> users = _userRepository.Delete(userId);
                if (users.Count < 3)
                    return Ok(users);
                else
                    return Ok("User id does not exist! Please enter a valid user Id!");
            }
            return Ok("User Id cannot be a null or Zero!");
            
        }
    }
}
