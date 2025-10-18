using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week_2_Inno_PreTrainee.Core.Interfaces;

namespace Week_2_Inno_PreTrainee.Application.Services.Console
{
    public class ConsoleInputService : IInputService
    {
        public string ReadLine()
        {
            return System.Console.ReadLine().Trim();
        }

        public ConsoleKeyInfo ReadKey()
        {
            return System.Console.ReadKey();
        }
    }
}
