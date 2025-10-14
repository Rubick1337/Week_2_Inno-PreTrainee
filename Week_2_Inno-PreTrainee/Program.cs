using Week_2_Inno_PreTrainee.Application.Services;
using Week_2_Inno_PreTrainee.Application.UI;
using Week_2_Inno_PreTrainee.Core.Factories;
using Week_2_Inno_PreTrainee.Core.Interfaces;
using Week_2_Inno_PreTrainee.Core.Services;
using Week_2_Inno_PreTrainee.Infrastructure.Data.Factories;
using Week_2_Inno_PreTrainee.Infrastructure.Migrations;
using Week_2_Inno_PreTrainee.Infrastructure.Repository;

class Program
{
    static async Task Main(string[] args)
    {
        var connectionString = ConfigReader.GetConnectionString("SqlServer");

        RunMigrations.ExecuteMigratuins(connectionString);

        DatabaseConnectionFactory factory = new SqlServerFactory(connectionString);
        IDataBaseConnection sqlServer = factory.CreateConnection();
        sqlServer.Open();

        try
        {
            var dbConnection = sqlServer.GetConnection();
            var taskRepository = new SqlServerTaskRepository(dbConnection);
            var taskService = new TaskService(taskRepository);
            var taskManager = new TaskManager(taskService);
            var menuManager = new MenuManager(taskManager);

            await menuManager.RunAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex.Message}");
            Console.ReadKey();
        }
        finally
        {
            sqlServer.Close();
        }
    }
}