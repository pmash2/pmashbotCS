using pmashbotCS.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pmashbotCS.Commands
{
    public class Gift : ICommand
    {
        public string Execute(string username, string[] args)
        {
            // !gift bob 5 <-- I give bob 5 points
            string receiver = args[1];
            int pointsToGift = int.Parse(args[2]);
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
