using TwitchLib.Client.Enums;

namespace pmashbotCS.Commands
{
    interface ICommand
    {
        public UserType ProtectionLevel { get; set; }
        public string Execute(string username, string[] args);
    }
}
