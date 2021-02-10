using pmashbotCS.Helpers;
using pmashbotCS.Models;
using TwitchLib.Client.Enums;

namespace pmashbotCS.Commands
{
    public class Gift : ICommand
    {
        public UserType ProtectionLevel { get; set; }
        public string Execute(string username, string[] args, BotSettings settings)
        {
            // !gift bob 5 <-- I give bob 5 points
            if (args.Length < 3)
            {
                return $"@{username}, to gift 10 points say !gift username 10";
            }

            string receiver = args[1];
            int pointsToGift = 0;
            if (!int.TryParse(args[2], out pointsToGift))
            {
                return $"@{username}, you need to specify a number of points to use with your !gift";
            }
            string notes = "";

            for (var i = 3; i < args.Length; i++)
            {
                notes += " " + args[i];
            }

            PointsManager mgr = new();
            int usersPoints = mgr.GetPoints(username);

            if (pointsToGift < 0)
            {
                return $"@{username}, you can't gift negative points!";
            }
            else if (usersPoints < pointsToGift)
            {
                return $"@{username}, you do not have enough points to fulfill this gift!";
            }
            else
            {
                mgr.ChangePoints(receiver, username, pointsToGift, notes);
                mgr.ChangePoints(username, "", pointsToGift * -1, notes);
                return $"@{username} has gifted {pointsToGift} points to {receiver}!";
            }
        }
    }
}
