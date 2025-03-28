using Newtonsoft.Json.Linq;
using System.IO;

namespace DragAndDropAutomation.Tests.Utilities
{
    public class ConfigReader
    {
        private static readonly string configFilePath = "appsettings.json";

        public static string? GetConfigValue(string key)
        {
            var json = File.ReadAllText(configFilePath);
            var config = JObject.Parse(json);
            return config[key]?.ToString();
        }
    }
}
