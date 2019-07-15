using Domain.Models;
using System;
using System.IO;

namespace Domain.Helpers
{
    public class ConfigFileReader
    {
        private string[] _configFile;
        
        public ConfigFileReader()
        {
            try
            {
                var currentDirectory = Directory.GetCurrentDirectory();
                var solutionPath = currentDirectory.Remove(currentDirectory.IndexOf("DependencyInjectionTests") + "DependencyInjectionTests".Length);

                var configFilePath = solutionPath + "\\appconfig.txt";
                _configFile = File.ReadAllLines(configFilePath);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.StackTrace);
                throw new FileNotFoundException("config file not found! Be sure that appconfig.txt is placed in main solution folder!");
            }
        }

        public Credentials GetCredentials()
        {
            return new Credentials
            {
                Username = _configFile[0],
                Password = _configFile[1]
            };
        }
    }
}
