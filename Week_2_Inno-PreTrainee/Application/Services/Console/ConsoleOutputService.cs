using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week_2_Inno_PreTrainee.Core.Interfaces;

namespace Week_2_Inno_PreTrainee.Application.Services.Console
{
    public class ConsoleOutputService : IOutputService
    {
        public void WriteLine(string message)
        {
            System.Console.WriteLine(message);
        }

        public void WriteError(string message)
        {
            System.Console.WriteLine(message);
        }
        public void Clear()
        {
            System.Console.Clear();
        }
    }
}
