using pmashbotCS.Helpers;
using pmashbotCS.Models;
using System;
using TwitchLib.Client.Enums;

namespace pmashbotCS.Commands
{
    public class AddConfig : ICommand
    {
        public UserType ProtectionLevel { get; set; }
        public string Execute(string username, string[] args, BotSettings settings)
        {
            // !addconfig PTS multiplier 2

            if (args.Length < 4)
            {
                return $"@{username}, try !addcommand PTS multiplier 2";
            }

            string key = args[1];
            string description = args[2];
            string value = args[3];

            GlobalConfigsManager cfgMgr = new();

            if (cfgMgr.GetConfig(key) != null)
            {
                return $"@{username}, that configuration already exists : {key}";
            }

            using (var context = new mashDbContext())
            {
                GlobalConfigs cfg = new()
                {
                    Key = key,
                    Description = description,
                    Value = value,
                    DateUpdated = DateTime.Now
                };

                context.GlobalConfigs.Add(cfg);
                context.SaveChanges();
            }

            return $"@{username}, configuration saved";
        }
    }
}
