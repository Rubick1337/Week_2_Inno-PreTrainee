using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week_2_Inno_PreTrainee.Core.Factories;
using Week_2_Inno_PreTrainee.Core.Interfaces;
using Week_2_Inno_PreTrainee.Infrastructure.Data.Products;

namespace Week_2_Inno_PreTrainee.Infrastructure.Data.Factories
{
    internal class SqlServerFactory : DatabaseConnectionFactory
    {
        private readonly string _stringConnection;

        public SqlServerFactory(string stringConnection)
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
