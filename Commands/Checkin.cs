using pmashbotCS.Helpers;
using pmashbotCS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchLib.Client.Enums;

namespace pmashbotCS.Commands
{
    public class Checkin : ICommand
    {
        public UserType ProtectionLevel { get; set; }

        public string Execute(string username, string[] args, BotSettings settings)
        {
            int pointsToGive = 0;
            if (!int.TryParse(settings.GlobalSettings.Where(x => x.Key == "CHECKIN").Select(y => y.Value).FirstOrDefault(), out pointsToGive))
            {
                return "Invalid check-in amount configured!";
            }
            PointsManager mgr = new();
            mgr.ChangePoints(username, "pmashbot", pointsToGive, "Checked in!");

            return $"@{username}, thanks for checking in! You just got yourself {pointsToGive} points!";
        }
    }
}
