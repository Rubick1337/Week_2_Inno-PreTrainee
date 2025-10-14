using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_2_Inno_PreTrainee.Application.Services
{
    public static class ConfigReader
    {
        private static IConfiguration _configuration;

        static ConfigReader()
        {
            try
            {
                _configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .Build();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }

        public static string GetConnectionString(string name)
        {
            try
            {
                var connectionString = _configuration?.GetConnectionString(name);
                return connectionString;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                throw;
            }
        }
    }
}
