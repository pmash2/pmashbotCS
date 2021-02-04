using System.Collections.Generic;
using pmashbotCS.Models;
using System.Linq;
using TwitchLib.Client.Enums;

namespace pmashbotCS.Commands
{
    public class RecordStats : ICommand
    {
        public UserType ProtectionLevel { get; set; }
        public string Execute(string username, string[] args)
        {
            return GetRecord(username);
        }

        public static string GetRecord(string userName)
        {
            var message = "";
            var records = new List<WinLoss>();

            using (var context = new mashDbContext())
            {
                records = context.WinLoss.Where(x => x.UserName == userName).ToList();
            }

            var wins = records.Where(x => x.DidWin == true).Count();
            var losses = records.Count - wins;

            message = $"{userName}'s current win loss record is : {wins} - {losses}";
            return message;
        }
    }
}
