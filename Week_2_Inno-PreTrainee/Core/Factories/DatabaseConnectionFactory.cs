using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week_2_Inno_PreTrainee.Core.Interfaces;

namespace Week_2_Inno_PreTrainee.Core.Factories
{
    internal abstract class DatabaseConnectionFactory
    {
        public abstract IDataBaseConnection CreateConnection();
    }
}
