using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week_2_Inno_PreTrainee.Core.Interfaces;

namespace Week_2_Inno_PreTrainee.Application.Services.Config
{
    public class ConfigReader
    {
        private static IConfiguration _configuration;
        private readonly IOutputService _outputService;

        


        public ConfigReader(IOutputService outputService)
        {
            _outputService = outputService;
            try
            {
                _configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .Build();
            }
            catch (Exception ex)
            {
                _outputService.WriteLine($"{ex.Message}");
            }
        }

        public string GetConnectionString(string name)
        {
            try
            {
                var connectionString = _configuration?.GetConnectionString(name);
                return connectionString;
            }
            catch (Exception ex)
            {
                _outputService.WriteLine($"{ex.Message}");
                throw;
            }
        }
    }
}
