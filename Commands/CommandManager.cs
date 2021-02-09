using System.Collections.Generic;
using TwitchLib.Client.Models;
using TwitchLib.Client.Enums;

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
        }

        public string ExecuteCommand(ChatMessage msgObj)
        {
            string[] args = msgObj.Message.Split(' ');

            ICommand commandToRun;
            try
            {
                commandToRun = GetCommand(args[0]);
            }
            catch
            {
                return ("Unknown command!");
            }

            if (!CanUseCommand(commandToRun, msgObj))
            {
                return $"@{msgObj.Username}, you are unable to use that command";
            }

            return commandToRun.Execute(msgObj.Username, args);
        }

        public bool InCommandFormat(string message)
        {
            return message.StartsWith("!");
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
