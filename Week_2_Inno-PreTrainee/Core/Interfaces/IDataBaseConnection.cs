using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_2_Inno_PreTrainee.Core.Interfaces
{
    internal interface IDataBaseConnection
    {
        IDbConnection GetConnection();
        string GetDatabaseType();
    }
}
