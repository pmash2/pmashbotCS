using pmashbotCS.Models;
using System;
using TwitchLib.Client.Enums;

namespace pmashbotCS.Commands
{
    public class AddTodaysMessage : ICommand
    {
        public UserType ProtectionLevel { get; set; }
        public string Execute(string username, string[] args)
        {
            string result;
            if (username == "pmash2")
            {
                var message = new TodaysMessage
                {
                    Message = String.Join(' ', args, 1, args.Length - 1),
                    Date = DateTime.Now
                };

                using (var context = new mashDbContext())
                {
                    context.TodaysMessage.Add(message);
                    context.SaveChanges();
                }

                result = "Today's message has been updated";
            }
            else
            {
                result = "Sorry, you're not allowed to do that";
            }

            return result;
        }
    }
}
