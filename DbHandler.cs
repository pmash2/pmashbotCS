using pmashbotCS.Models;
using System;
using System.Linq;

namespace pmashbotCS
{
    public class DbHandler
    {
        public void Test()
        {
            using (var context = new mashDbContext())
            {
                // Add user.
                context.Users.Add(new Users
                {
                    Name = "pmash2",
                    EntryDate = DateTime.Now
                });
                context.Users.Add(new Users
                {
                    Name = "hunter2140",
                    EntryDate = DateTime.Now
                });
                context.SaveChanges();

                // Fetch Reminders
                var users = context.Users.ToArray();
                foreach (var user in users)
                {
                    Console.WriteLine($"We found user {user.Name}!");
                }
            }
        }
    }
}
