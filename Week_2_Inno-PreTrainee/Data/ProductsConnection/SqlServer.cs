using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Data.SqlClient;
using Week_2_Inno_PreTrainee.Data.Interfaces;

namespace Week_2_Inno_PreTrainee.Data.ProductsConnection
{
    public class SqlServer : IDataBaseConnection
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
        public void Open()
        {
            _connection.Open();
        }
        public void Close()
        {
            _connection.Close();
        }
    }
}
