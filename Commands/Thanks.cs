using pmashbotCS.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchLib.Client.Enums;

namespace pmashbotCS.Commands
{
    public class Thanks : ICommand
    {
        public UserType ProtectionLevel { get; set; }

        public string Execute(string username, string[] args)
        {
            // !thanks bob 5 for being awesome
            if (args.Length < 4)
            {
                return $"@{username}, to say thanks, say !thanks bob 5, and be sure to include a reason!";
            }

            string receiver = args[1];

            int pointsToGift = 0;
            if (!int.TryParse(args[2], out pointsToGift))
            {
                return $"@{username}, you need to specify a number of points to use with your !thank";
            }
            string notes = "";

            for (var i = 3; i < args.Length; i++)
            {
                notes += " " + args[i];
            }

            PointsManager mgr = new();
            
            if(pointsToGift <= 0)
            {
                return $"@{username}, you can't say thanks with negative points!";
            }
            else if(receiver == username)
            {
                return $"@{username}, you can't pat yourself on the back like that!";
            }
            else
            {
                mgr.ChangePoints(receiver, username, pointsToGift, notes);
                return $"@{username} has given {pointsToGift} points to @{receiver} {notes}!";
            }
        }
    }
}
