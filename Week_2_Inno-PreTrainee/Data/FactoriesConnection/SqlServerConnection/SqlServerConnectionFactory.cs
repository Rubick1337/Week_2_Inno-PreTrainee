using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week_2_Inno_PreTrainee.Data.Factories;
using Week_2_Inno_PreTrainee.Data.Interfaces;
using Week_2_Inno_PreTrainee.Data.ProductsConnection;

namespace Week_2_Inno_PreTrainee.Data.FactoriesConnection.SqlServerConnecyion
{
    internal class SqlServerConnectionFactory : DatabaseConnectionFactory
    {
        private readonly string _stringConnection;

        public SqlServerConnectionFactory(string stringConnection)
        {
            _stringConnection = stringConnection;
        }
        public override IDataBaseConnection CreateConnection()
        {
            IDataBaseConnection connection = new SqlServer(_stringConnection);
            return connection;
        }
    }
}
