using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserRegistrationAPI.Models
{
    public class MockUserRepository : IUserRepository
    {
        public DbSet<User> Users { get; set; }
        public MockUserRepository()
        {
            int id = 1;
            User user = new User() { userId = id, userName = "John" };
            Users.Add(user);
            user = new User() { userId = Users.Local.Max(u => u.userId) + 1, userName = "James" };
            Users.Add(user);

        }

        public List<User> Create(string newUserName)
        {
            var existingUser = Users.Local.Where(u => u.userName.ToLower() == newUserName.ToLower()).FirstOrDefault();
            if (existingUser == null)
            {
                User user = new User() { userId = Users.Local.Max(u => u.userId) + 1, userName = newUserName };
                Users.Local.Add(user);
            }
            return Users.Local.ToList();
        }

        public List<User> Delete(int userId)
        {
            if (userId != 0)
            {
                var existingUser = Users.Local.Where(u => u.userId == userId).FirstOrDefault();
                if (existingUser != null)
                {
                    var itemToRemove = Users.Local.Single(u => u.userId == userId);
                    Users.Local.Remove(itemToRemove);
                }
            }
            return Users.Local.ToList();
        }

        public List<User> Get()
        {
            return Users.Local.ToList();
        }

        public List<User> Update(int userId, string updatedUserName)
        {
            if (userId != 0 && !string.IsNullOrEmpty(updatedUserName))
            {
                //Check if user Is exists
                var existingUser = Users.Local.Where(u => u.userId == userId).FirstOrDefault();
                if (existingUser != null)
                {
                    existingUser.userId = existingUser.userId;
                    existingUser.userName = updatedUserName;

                    Delete(existingUser.userId);

                    Users.Local.Add(existingUser);

                }
            }

            return Users.Local.ToList();
        }
    }
}
