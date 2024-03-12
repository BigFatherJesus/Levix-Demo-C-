using System;
using System.Configuration;
using System.IO;

namespace LevixDemoApp.Configuration
{
    public class AppSettings
    {
        private System.Configuration.Configuration config;

        public AppSettings()
        {
            try
            {
                var configMap = new ExeConfigurationFileMap { ExeConfigFilename = "app.config" }; // Path to your config file
                config = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);
                Console.WriteLine("Configuration loaded successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading configuration: {ex.Message}\n{ex.StackTrace}");
            }
        }

        public void SaveSetting(string key, string value)
        {
            try
            {
                if (config.AppSettings.Settings[key] == null)
                {
                    config.AppSettings.Settings.Add(key, value);
                }
                else
                {
                    config.AppSettings.Settings[key].Value = value;
                }
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
                Console.WriteLine($"Setting {key} saved successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving setting {key}: {ex.Message}\n{ex.StackTrace}");
            }
        }

        public string GetSetting(string key)
        {
            try
            {
                string setting = config.AppSettings.Settings[key]?.Value;
                Console.WriteLine($"Retrieved setting {key}: {setting}");
                return setting;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving setting {key}: {ex.Message}\n{ex.StackTrace}");
                return null;
            }
        }

        public void DeleteSetting(string key)
        {
            try
            {
                config.AppSettings.Settings.Remove(key);
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
                Console.WriteLine($"Setting {key} deleted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting setting {key}: {ex.Message}\n{ex.StackTrace}");
            }
        }
    }
}