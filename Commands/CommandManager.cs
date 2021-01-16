﻿using System.Collections.Generic;

namespace pmashbotCS.Commands
{
    public class CommandManager
    {
        Dictionary<string, ICommand> Commands;

        public CommandManager()
        {
            Commands = new Dictionary<string, ICommand>();
            Commands.Add("!bet", new OddOrEven());
            Commands.Add("!record", new RecordStats());
        }

        public string ExecuteCommand(string username, string[] args, string command)
        {
            ICommand commandToRun;
            try
            {
                commandToRun = GetCommand(command);
            }
            catch
            {
                return ("Unknown command!");
            }

            return commandToRun.Execute(username, args);
        }

        public bool InCommandFormat(string message)
        {
            return message.StartsWith("!");
        }

        private ICommand GetCommand(string command)
        {
            return Commands[command];
        }
    }
}
