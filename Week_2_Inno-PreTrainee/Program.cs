using Week_2_Inno_PreTrainee.Infrastructure.Data.Factories;
using System.Data;
using Week_2_Inno_PreTrainee.Core.Factories;
using Week_2_Inno_PreTrainee.Core.Interfaces;

namespace Week_2_Inno_PreTrainee
{
    class Program
    {
        static void Main(string[] args)
        {
            DatabaseConnectionFactory factory = new SqlServerFactory("Server=DESKTOP-30H8C5P;Database=Inno_Course;Trusted_Connection=true;TrustServerCertificate=true;");
            IDataBaseConnection sqlServer = factory.CreateConnection();
            Console.WriteLine(sqlServer.GetDatabaseType());
            sqlServer.GetConnection().Open();
        }
    }
}