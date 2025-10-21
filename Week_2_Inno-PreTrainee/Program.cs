using FluentMigrator.Runner.Processors.SqlServer;
using Week_2_Inno_PreTrainee.Application.ConsoleHandler;
using Week_2_Inno_PreTrainee.Application.Interafaces;
using Week_2_Inno_PreTrainee.Core.Services;
using Week_2_Inno_PreTrainee.Data.Factories;
using Week_2_Inno_PreTrainee.Data.FactoriesConnection.SqlServerConnecyion;
using Week_2_Inno_PreTrainee.Data.Interfaces;
using Week_2_Inno_PreTrainee.Infrastructure.Repository;
using Week_2_Inno_PreTrainee.Application.Application;
using Week_2_Inno_PreTrainee.Infrastructure.Migrations;

class Program
{
    static async Task Main(string[] args)
    {
        const string CONNECTION = "Server=.;Database=Inno_Course;Trusted_Connection=True;TrustServerCertificate=True";

        var inputOutputHandler = new InputOutputHandler();
        DatabaseConnectionFactory dbFactory = new SqlServerConnectionFactory(CONNECTION);
        RunMigrations.ExecuteMigrations(CONNECTION);
        IDataBaseConnection sqlServer = dbFactory.CreateConnection();

        sqlServer.Open();
        try
        {
            var repository = new SqlServerTaskRepository(sqlServer.GetConnection());

            ITaskService taskService = new TaskService(repository);

            var app = new Application(inputOutputHandler, taskService);

            await app.RunAsync();
        }
        catch (Exception ex)
        {
            inputOutputHandler.WriteError(ex.Message);
        }
        finally
        {
            sqlServer.Close();
        }
    }
}