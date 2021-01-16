using pmashbotCS.Models;
using System;

namespace pmashbotCS.Commands
{
    public class OddOrEven : ICommand
    {
        public string Execute(string username, string[] args)
        {
            bool betEven = args[1] == "even" ? true : false;

            return PlayGame(betEven, username);
        }

        public static string PlayGame(bool betEven, string userName)
        {
            var rand = new Random();
            var number = rand.Next(0, 1000);
            var didWin = false;

            Console.WriteLine($"The random number for this round is {number}");

            var isEven = number % 2 == 0 ? true : false;

            string result = $"The number was {number}. ";

            if (betEven && isEven || !betEven && !isEven)
            {
                result += "YOU WIN!!!!";
                didWin = true;
            }
            else
            {
                result += "Oh no, you lose! :(";
                didWin = false;
            }

            using (var context = new mashDbContext())
            {
                context.WinLoss.Add(new WinLoss
                {
                    UserName = userName,
                    DidWin = didWin,
                    Date = DateTime.Now,
                    Game = "OddOrEven"
                });
                context.SaveChanges();
            }

            return result;
        }
    }
}
