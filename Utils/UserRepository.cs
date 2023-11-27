using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TemplateAudacesApi.Models;

namespace TemplateAudacesApi.Utils
{
    public class UserRepository
    {
        public static User Get(string username, string password)
        {
            var users = new List<User>();
            users.Add(new User { username = "batman", password = "batman", role = "manager" });
            users.Add(new User { username = "robin", password = "robin", role = "employee" });
            users.Add(new User { username = "demo", password = "demo", role = "demo" });
            return users.Where(x => x.username.ToLower() == username.ToLower() && x.password == x.password).FirstOrDefault();
        }
    }
}
