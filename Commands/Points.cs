using pmashbotCS.Helpers;

namespace pmashbotCS.Commands
{
    public class Points : ICommand
    {
        public string Execute(string username, string[] args)
        {
            PointsManager mgr = new();
            var msg = $"@{username}, you have {mgr.GetPoints(username)} points!";
            return msg;
        }
    }
}
