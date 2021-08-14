using RestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPI
{
    public class UsersRepository
    {
        public List<User> Users { get; set; }
        
        public UsersRepository()
        {
            var user = new User("test@gmail.com", "abc123");
            Users = new List<User>()
            {
                new User("test@gmail.com", "abc123")                
            };
        }

        public void AddUser(User user)
        {
            Users.Add(new User(user.Email, user.Password));
        }

        public User GetUserById(Guid id)
        {
            return Users.FirstOrDefault(u => u.Id == id);
        }

        public User UpdateUser(User user, User update)
        {
            if (update.Email != null)
            {
                user.Email = update.Email;
            }

            if (update.Password != null)
            {
                user.Password = update.Password;
            }

            Remove(user.Id);
            Users.Add(user);

            return user;
        }

        public bool Exists(Guid id)
        {
            var user = Users.FirstOrDefault(u => u.Id == id);
            return !(user is null);
        }

        public bool CheckEmail(string email)
        {
            var user = Users.FirstOrDefault(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
            return !(user is null);
        }
        public void Remove(Guid id)
        {
            Users = Users.Where(u => u.Id != id).ToList();
        }
    }
}
