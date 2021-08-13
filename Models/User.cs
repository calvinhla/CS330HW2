using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RestAPI.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
        public DateTime CreationDate { get; set; }

        public User(string email, string password)
        {
            Id = Guid.NewGuid();
            CreationDate = DateTime.UtcNow; 
            Email = email;
            Password = password;
        }
    }
}
