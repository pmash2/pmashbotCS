using pmashbotCS.Models;
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
    }
}
