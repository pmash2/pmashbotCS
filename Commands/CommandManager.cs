using System.Collections.Generic;

namespace pmashbotCS.Commands
{
    public class CommandManager
    {
        ICommand OddOrEven;
        ICommand RecordStats;

        public CommandManager()
        {
            OddOrEven = new OddOrEven();
            RecordStats = new RecordStats();
        }

        public string ExecuteCommand(string username, string[] args, string command)
        {
            switch (command)
            {
                case "!bet":
                    return OddOrEven.Execute(username, args);
                case "!record":
                    return RecordStats.Execute(username, args);
                default:
                    return "Unknown command!";
            }
        }

        public bool InCommandFormat(string message)
        {
            return message.StartsWith("!");
        }

        private bool CommandExists(string command)
        {
            bool exists = false;

            switch (command)
            {
                case "!bet":
                    exists = true;
                    break;
                case "!record":
                    exists = true;
                    break;
                default:
                    exists = false;
                    break;
            }

            return exists;
        }
    }
}
