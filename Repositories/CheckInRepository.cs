using pmashbotCS.Models;
using System;
using System.Linq;

namespace pmashbotCS.Repositories
{
    public static class CheckInRepository
    {
        public static DateTime GetLastCheckIn(string username)
        {
            DateTime lastCheckIn;
            using (var context = new mashDbContext())
            {
                lastCheckIn = context.TransactionLog
                                     .Where(x => x.Notes == "Checked in!")
                                     .Where(x => x.Receiver == username)
                                     .OrderByDescending(x => x.Date)
                                     .Select(x => x.Date)
                                     .FirstOrDefault();
            }

            return lastCheckIn;
        }
    }
}
