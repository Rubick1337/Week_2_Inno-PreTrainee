using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week_2_Inno_PreTrainee.Core.Interfaces;

using Microsoft.Data.SqlClient;

namespace Week_2_Inno_PreTrainee.Infrastructure.Data.Products
{
    internal class SqlServer : IDataBaseConnection
    {
        private readonly SqlConnection _connection;
        private readonly string _typeDataBase;

        public SqlServer(string connection)
        {
            _connection = new SqlConnection(connection);
            _typeDataBase = "SqlServer";
        }
        public string GetDatabaseType()
        {
            return _typeDataBase;
        }
        public IDbConnection GetConnection()
        {
        return _connection; 
        }
    }
}
