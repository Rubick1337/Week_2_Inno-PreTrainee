using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week_2_Inno_PreTrainee.Application.Handler;
using Week_2_Inno_PreTrainee.Core.Interfaces;

namespace Week_2_Inno_PreTrainee.Application.Services.Config
{
    public class ConfigReader
    {
        private static IConfiguration _configuration;
        private readonly IOutputService _outputService;
        private readonly ExceptionHandler _exceptionHandler;

        


        public ConfigReader(IOutputService outputService, ExceptionHandler exceptionHandler)
        {
            _exceptionHandler = exceptionHandler;
            _outputService = outputService;
            _exceptionHandler.HandleVoid(() =>
            {
                _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();
            });
        }

        public string GetConnectionString(string name)
        {
            return _exceptionHandler.HandleValueWithThrow(() =>
                   _configuration?.GetConnectionString(name));
        }
    }
}
