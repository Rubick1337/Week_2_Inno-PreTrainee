using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_2_Inno_PreTrainee.Core.Interfaces
{
    public interface IInputService
    {
        string ReadLine();
        ConsoleKeyInfo ReadKey();
    }
}
