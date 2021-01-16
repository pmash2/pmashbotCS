
namespace pmashbotCS.Commands
{
    public class CommandManager
    {
        public bool InCommandFormat(string message)
        {
            return message.StartsWith("!");
        }

        public bool CommandExists(string command)
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
