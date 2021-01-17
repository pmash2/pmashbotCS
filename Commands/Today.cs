using pmashbotCS.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace pmashbotCS.Commands
{
    public class Today : ICommand
    {
        public string Execute(string username, string[] args)
        {
            var records = new List<TodaysMessage>();
            string message;

            using(var context = new mashDbContext())
            {
                records = context.TodaysMessage
                                 .Where(x => x.Date >= DateTime.Now.Date)
                                 .Where(x => x.Date <= DateTime.Now.AddDays(1).Date)
                                 .OrderBy(x => x.Date)
                                 .ToList();
            }

            if (records.Count == 1)
            {
                message = records.First().Message;
            }
            else if (records.Count > 1)
            {
                message = records.Last().Message;
            }
            else
            {
                message = "I don't know what we're doing today!";
            }

            return message;
        }
    }
}
