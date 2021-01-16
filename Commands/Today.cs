
namespace pmashbotCS.Commands
{
    public class Today : ICommand
    {
        public string Execute(string username, string[] args)
        {
            return "Today we're gonna have a good time!";
        }
    }
}
