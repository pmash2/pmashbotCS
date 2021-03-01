using pmashbotCS.Helpers;
using System.Collections.Generic;

namespace pmashbotCS.Models
{
    public class BotSettings
    {
        public BotSettings(string endpoint)
        {
            ConfigsManager = new();
            GlobalSettings = ConfigsManager.GetAllConfigs();
            Endpoint = endpoint;
        }
        public List<GlobalConfigs> GlobalSettings { get; set; }
        private GlobalConfigsManager ConfigsManager { get; set; }

        public string Endpoint { get; set; }

        public void RefreshSettings()
        {
            GlobalSettings.Clear();
            GlobalSettings = ConfigsManager.GetAllConfigs();
            //System.Console.WriteLine($"{PrintConfigs()}");
        }

        private string PrintConfigs()
        {
            string s = "";
            foreach (var setting in GlobalSettings)
            {
                s += $", {setting.Key} - {setting.Value}";
            }

            return s;
        }
    }
}
