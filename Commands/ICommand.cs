
namespace pmashbotCS.Commands
{
    interface ICommand
    {
        public string Execute(string username, string[] args);
    }
}
