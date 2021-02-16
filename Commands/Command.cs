using pmashbotCS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchLib.Client.Enums;
using pmashbotCS.Repositories;

namespace pmashbotCS.Commands
{
    public class Command : ICommand
    {
        public UserType ProtectionLevel { get; set; }

        public string Execute(string username, string[] args, BotSettings settings)
        {
            /*
              !command add pmash The coolest guy around
              !command update pmash Some other dude
              !command delete pmash
            */
            string subCommand = args[1];
            string cmdKeyword = args[2];
            string cmdText = String.Join(' ', args, 3, args.Length - 3);

            StaticCommands cmd = new()
            {
                Keyword = cmdKeyword,
                Text = cmdText
            };

            var returnText = "";
            switch (subCommand)
            {
                case "add" :
                    if (!StaticCommandsRepository.CommandExists(cmd.Keyword))
                    {
                        StaticCommandsRepository.CreateCommand(cmd);
                        returnText = $"{cmd.Keyword} command created successfully!";
                    }
                    else
                    {
                        returnText = $"{cmd.Keyword} command already exists!";
                    }
                    break;
                case "update" :
                    if (StaticCommandsRepository.CommandExists(cmd.Keyword))
                    {
                        StaticCommandsRepository.UpdateCommand(cmd);
                        returnText = $"{cmd.Keyword} command updated successfully!";
                    }
                    else
                    {
                        returnText = $"{cmd.Keyword} command doesn't exist!";
                    }
                    break;
                case "remove":
                    if (StaticCommandsRepository.CommandExists(cmd.Keyword))
                    {
                        StaticCommandsRepository.DeleteCommand(cmd);
                        returnText = $"{cmd.Keyword} command removed successfully!";
                    }
                    else
                    {
                        returnText = $"{cmd.Keyword} command doesn't exist!";
                    }
                    break;
                default:
                    break;
            }

            return returnText;
        }
    }
}
