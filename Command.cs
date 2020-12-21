using System;

namespace pmashbotCS
{
    public static class Command
    {
        public static string PlayGame(bool betEven)
        {
            var rand = new Random();
            var number = rand.Next(0, 1000);
            Console.WriteLine($"The random number for this round is {number}");

            var isEven = number % 2 == 0 ? true : false;

            string result = $"The number was {number}. ";

            if (betEven && isEven || !betEven && !isEven)
            {
                result += "YOU WIN!!!!";
            }
            else
            {
                result += "We suck again! :(";
            }

            return result;
        }
    }
}
