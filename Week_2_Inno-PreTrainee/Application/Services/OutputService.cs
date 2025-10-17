using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week_2_Inno_PreTrainee.Core.Interfaces;

namespace Week_2_Inno_PreTrainee.Application.Services
{
    public class OutputService : IOutputService
    {
        static public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
       static public void WriteError(string message) 
        { 
            Console.WriteLine(message); 
        }
    }
}
