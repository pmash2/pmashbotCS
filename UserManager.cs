using pmashbotCS.Models;
using System;
using System.Linq;

namespace pmashbotCS
{
    public static class UserManager
    {
        public static bool UserInDatabase(string username)
        {
            Users user;

            using (var context = new mashDbContext())
            {
                user = context.Users.Where(x => x.Name == username).FirstOrDefault();
            }

            return !(user is null);
        }

        public static void AddUser(string username)
        {
            var user = new Users
            {
                Name = username,
                EntryDate = DateTime.Now
            };

            using (var context = new mashDbContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
        }
    }
}
