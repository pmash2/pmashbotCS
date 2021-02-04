﻿using pmashbotCS.Models;
using System;

namespace pmashbotCS.Commands
{
    public class AddConfig : ICommand
    {
        public string Execute(string username, string[] args)
        {
            // !addcommand PTS	multiplier 2

            if (args.Length < 4)
            {
                return $"@{username}, try !addcommand PTS multiplier 2";
            }

            string key = args[1];
            string description = args[2];
            string value = args[3];

            using (var context = new mashDbContext())
            {
                GlobalConfigs cfg = new()
                {
                    Key = key,
                    Description = description,
                    Value = value,
                    DateUpdated = DateTime.Now
                };

                context.GlobalConfigs.Add(cfg);
                context.SaveChanges();
            }

            return $"@{username}, configuration saved";
        }
    }
}
