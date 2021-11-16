using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserRegistrationAPI.Models
{
    public interface IUserRepository
    {
        public List<User> Create(string newUserName);
        public List<User> Update(int userId, string updatedUserName);
        public List<User> Delete(int userId);
        public List<User> Get();
    }
}
