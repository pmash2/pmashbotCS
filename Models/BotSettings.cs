using System.Collections.Generic;
using System.Linq;

namespace pmashbotCS.Models
{
    public class BotSettings
    {
        public BotSettings()
        {
            GlobalSettings = GetConfigs();
        }
        public List<GlobalConfigs> GlobalSettings { get; set; }

        public void RefreshSettings()
        {
            GlobalSettings.Clear();
            GlobalSettings = GetConfigs();
        }

        private List<GlobalConfigs> GetConfigs()
        {
            List<GlobalConfigs> settings = new();
            using (var context = new mashDbContext())
            {
                settings = context.GlobalConfigs.ToList();
            }

            string s = "";

            foreach (var setting in settings)
            {
                s += $", {setting.Key} - {setting.Value}";
            }

            System.Console.WriteLine($"Settings updated - {s}");

            return settings;
        }
    }
}
