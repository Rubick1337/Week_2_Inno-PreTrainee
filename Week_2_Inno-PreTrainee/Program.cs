using Week_2_Inno_PreTrainee.Application.Handler;
using Week_2_Inno_PreTrainee.Application.Services;
using Week_2_Inno_PreTrainee.Application.Services.Config;
using Week_2_Inno_PreTrainee.Application.Services.Console;
using Week_2_Inno_PreTrainee.Application.Services.Tasks;
using Week_2_Inno_PreTrainee.Application.UI;
using Week_2_Inno_PreTrainee.Application.Validator;
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
        var outputService = new ConsoleOutputService();
        var inputService = new ConsoleInputService();
        var exceptionHandler = new ExceptionHandler(outputService);
        var config = new ConfigReader(outputService,exceptionHandler);
        var connectionString = config.GetConnectionString("SqlServer");

        RunMigrations.ExecuteMigrations(connectionString);

        DatabaseConnectionFactory factory = new SqlServerFactory(connectionString);
        IDataBaseConnection sqlServer = factory.CreateConnection();
        sqlServer.Open();

        try
        {
            var dbConnection = sqlServer.GetConnection();
            var taskRepository = new SqlServerTaskRepository(dbConnection);
            var taskService = new TaskService(taskRepository, exceptionHandler);

            var inputValidator = new InputValidator(outputService,inputService);

            var displayService = new TaskDisplayService(outputService);
            var interactionService = new UserInteractionTaskService(outputService, inputService, inputValidator);
            var operationService = new TaskOperationService(taskService, exceptionHandler);

            var taskManager = new TaskManager(
                  operationService,
                  displayService,
                  interactionService,
                  outputService);

            var menuManager = new MenuManager(
             taskManager,
             outputService,
             inputValidator);

            await menuManager.RunAsync();
        }
        catch (Exception ex)
        {
            outputService.WriteLine($"{ex.Message}");
            inputService.ReadKey();
        }
        finally
        {
            sqlServer.Close();
        }
    }
}