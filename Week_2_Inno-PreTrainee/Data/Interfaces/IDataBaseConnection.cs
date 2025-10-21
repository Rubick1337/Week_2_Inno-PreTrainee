using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_2_Inno_PreTrainee.Data.Interfaces
{
    internal interface IDataBaseConnection
    {
        IDbConnection GetConnection();
        string GetDatabaseType();

        void Open();
        void Close();
    }
}
