using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_2_Inno_PreTrainee.Core.Interfaces
{
    public interface IOutputService
    {
        void WriteLine(string message);
        void WriteError(string message);
        void Clear();
    }
}
