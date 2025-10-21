using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week_2_Inno_PreTrainee.Data.Interfaces;

namespace Week_2_Inno_PreTrainee.Data.Factories
{
    internal abstract class DatabaseConnectionFactory
    {
        public abstract IDataBaseConnection CreateConnection();
    }
}
