using System;
using dotenv.net;
using dotenv.net.Utilities;
using pmashbotCS.Models;

namespace pmashbotCS
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var envReader = new EnvReader();
            DotEnv.Config(true, "mySecrets");
            var channel = envReader.GetStringValue("CHANNEL");
            var token = envReader.GetStringValue("BOT_PASSWORD");
            var bot = new Bot(channel, token);

#if DEBUG
            using (var context = new mashDbContext())
            {
                // TODO: Learn this versioning....
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

            }
#endif

            while (true)
            {
                System.Threading.Thread.Sleep(1000);
            }

            Console.WriteLine("We made it here without error!");
        }
    }
}
