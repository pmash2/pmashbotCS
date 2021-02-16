using pmashbotCS.Models;
using TwitchLib.Client.Enums;

namespace pmashbotCS.Commands
{
    public class StaticCommand : ICommand
    {
        public string ReturnString { get; set; }
        public UserType ProtectionLevel { get; set; }

        public string Execute(string username, string[] args, BotSettings settings)
        {
            return ReturnString;
        }
    }
}
