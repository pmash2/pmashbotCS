using System.Collections.Generic;
using TwitchLib.Client.Models;
using TwitchLib.Client.Enums;
using pmashbotCS.Models;
using pmashbotCS.Helpers;
using pmashbotCS.Repositories;

namespace pmashbotCS.Commands
{
    public class CommandManager
    {
        Dictionary<string, ICommand> Commands;

        public CommandManager()
        {
            Commands = new Dictionary<string, ICommand>();
            Commands.Add("!bet", new OddOrEven(){ ProtectionLevel = UserType.Viewer });
            Commands.Add("!record", new RecordStats(){ ProtectionLevel = UserType.Viewer });
            Commands.Add("!today", new Today(){ ProtectionLevel = UserType.Viewer });
            Commands.Add("!addtoday", new AddTodaysMessage(){ ProtectionLevel = UserType.Moderator });
            Commands.Add("!points", new Points(){ ProtectionLevel = UserType.Viewer });
            Commands.Add("!gift", new Gift(){ ProtectionLevel = UserType.Viewer });
            Commands.Add("!addconfig", new AddConfig(){ ProtectionLevel = UserType.Moderator });
            Commands.Add("!thanks", new Thanks() { ProtectionLevel = UserType.Moderator });
            Commands.Add("!checkin", new Checkin() { ProtectionLevel = UserType.Viewer });
            Commands.Add("!command", new Command() { ProtectionLevel = UserType.Moderator });
        }

        public string ExecuteCommand(ChatMessage msgObj, BotSettings settings)
        {
            string[] args = msgObj.Message.Split(' ');

            ICommand commandToRun;
            try
            {
                commandToRun = GetCommand(args[0]);
            }
            catch
            {
                return (MagicStrings.UnknownCommand);
            }

            if (!CanUseCommand(commandToRun, msgObj))
            {
                return $"@{msgObj.Username}, {MagicStrings.NoPermissions}";
            }

            return commandToRun.Execute(msgObj.Username, args, settings);
        }

        public bool InCommandFormat(string message)
        {
            return message.StartsWith(MagicStrings.CommandStart);
        }

        private ICommand GetCommand(string command)
        {
            return Commands[command];
        }

        private bool CanUseCommand(ICommand cmd, ChatMessage msg)
        {
            return cmd.ProtectionLevel <= msg.UserType;
        }
    }
}
