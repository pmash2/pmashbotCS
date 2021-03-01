using pmashbotCS.Models;
using System;
using TwitchLib.Client.Enums;
using pmashbotCS.Helpers;

namespace pmashbotCS.Commands
{
    public class AddTodaysMessage : ICommand
    {
        public UserType ProtectionLevel { get; set; }
        public string Execute(string username, string[] args, BotSettings settings)
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

                PostMessage(settings.Endpoint, message.Message);

                result = "Today's message has been updated";
            }
            else
            {
                result = "Sorry, you're not allowed to do that";
            }

            return result;
        }

        async private void PostMessage(string endpoint, string message)
        {
            await TodayMessagePoster.PostMessage(endpoint, message);
        }
    }
}
