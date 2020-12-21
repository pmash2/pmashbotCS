using System;
using dotenv.net;
using dotenv.net.Utilities;

namespace pmashbotCS
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var envReader = new EnvReader();
            DotEnv.Config(true, "C:\\Users\\pasht\\mySecrets");
            var channel = envReader.GetStringValue("CHANNEL");
            var token = envReader.GetStringValue("BOT_PASSWORD");
            var bot = new Bot(channel, token);

            Console.WriteLine("We made it here without error!");
        }
    }
}
