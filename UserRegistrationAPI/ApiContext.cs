using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserRegistrationAPI.Models
{
    public class ApiContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public ApiContext(DbContextOptions options) : base(options)
        {
            LoadUsers();
        }

        public void LoadUsers()
        {
            //int id = 1;
            User user = new User() { userId = 2, userName = "Peter" };
            Users.Add(user);
            user = new User() { userId = 1, userName = "John" };
            Users.Add(user);
            user = new User() { userId = 3, userName = "James" };
            Users.Add(user);
        }

        public List<User> GetUsers()
        {
            //return Users.Local.ToList<User>();
            return Users.Local.OrderBy(u=>u.userId).ToList();
        }

        public List<User> AddUser(string newUserName)
        {
            var existingUser = Users.Local.Where(u => u.userName.ToLower() == newUserName.ToLower()).FirstOrDefault();
            if (existingUser == null)
            {
                User user = new User() { userId = Users.Local.Max(u => u.userId) + 1, userName = newUserName };
                Users.Local.Add(user);
                //return "User has been added.";
            }
            //return "Duplicate user with same name is not allowed";
            return Users.Local.ToList();
        }

        public List<User> ModifyUser(int userId, string modifiedName)
        {
            if (userId != 0 && !string.IsNullOrEmpty(modifiedName))
            {
                //Check if user Is exists
                var existingUser = Users.Local.Where(u => u.userId == userId).FirstOrDefault();
                if (existingUser != null)
                {
                    existingUser.userId = existingUser.userId;
                    existingUser.userName = modifiedName;

                    DeleteUser(existingUser.userId);
                    
                    Users.Local.Add(existingUser);
                    
                }
                //return Users.Local.ToList();
            }

            return Users.Local.ToList();
        }

        public List<User> DeleteUser(int userId)
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
    }
}
