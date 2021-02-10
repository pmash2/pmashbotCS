using pmashbotCS.Helpers;
using pmashbotCS.Models;
using TwitchLib.Client.Enums;

namespace pmashbotCS.Commands
{
    public class Points : ICommand
    {
        public UserType ProtectionLevel { get; set; }
        public string Execute(string username, string[] args, BotSettings settings)
        {
            PointsManager mgr = new();
            var msg = $"@{username}, you have {mgr.GetPoints(username)} points!";
            return msg;
        }
    }
}
