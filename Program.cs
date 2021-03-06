﻿using System;
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
            var endpoint = envReader.GetStringValue("API_ENDPOINT");

#if DEBUG
            using (var context = new mashDbContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }
#endif

            BotSettings settings = new(endpoint);
            var bot = new Bot(channel, token, settings);

            while (true)
            {
                bot.settings.RefreshSettings();
                System.Threading.Thread.Sleep(1000);
            }

            Console.WriteLine("We made it here without error!");
        }
    }
}
