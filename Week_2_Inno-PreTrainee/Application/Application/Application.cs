using System.Threading.Tasks;
using Week_2_Inno_PreTrainee.Application.Interafaces;
using Week_2_Inno_PreTrainee.Application.ConsoleHandler;
using TaskEntity = Week_2_Inno_PreTrainee.Core.Entities.Task;
using Week_2_Inno_PreTrainee.Core.Entities;

namespace Week_2_Inno_PreTrainee.Application.Application
{
    public class Application
    {
        private readonly InputOutputHandler _inputOutputHandler;
        private readonly ITaskService _tasks;

        private enum MenuOptions
        {
            Exit = 0,
            ShowAll = 1,
            Add = 2,
            Delete = 3,
            MarkCompleted = 4,
            MarkIncomplete = 5
        }

        public Application(InputOutputHandler inputOutputHandler, ITaskService tasks)
        {
            _inputOutputHandler = inputOutputHandler;
            _tasks = tasks;
        }

        public async System.Threading.Tasks.Task RunAsync()
        {
            while (true)
            {
                PrintMenu();

                var choice = _inputOutputHandler.ReadMenuChoice(
                    "Выберите действие:",
                    (int)MenuOptions.Exit,
                    (int)MenuOptions.MarkIncomplete);

                switch ((MenuOptions)choice)
                {
                    case MenuOptions.ShowAll:
                        {
                            await DisplayTasksAsync();
                            _inputOutputHandler.ReadKey();
                            break;
                        }
                    case MenuOptions.Add:
                        {
                            _inputOutputHandler.Clear();
                            var title = _inputOutputHandler.ReadPositiveString("Введите название задачи:");
                            var description = _inputOutputHandler.ReadPositiveString("Введите описание задачи:");
                            await _tasks.CreateAsync(title, description);
                            break;
                        }
                    case MenuOptions.Delete:
                        {
                            _inputOutputHandler.Clear();
                            await DisplayTasksAsync();
                            var taskId = _inputOutputHandler.ReadPositiveInt("ID задачи для удаления:");
                            await _tasks.DeleteAsync(taskId);
                            break;
                        }
                    case MenuOptions.MarkCompleted:
                        {
                            _inputOutputHandler.Clear();
                            await DisplayTasksAsync();
                            var taskId = _inputOutputHandler.ReadPositiveInt("ID задачи для отметки как выполненной:");
                            await _tasks.UpdateStatusAsync(taskId, true);
                            break;
                        }
                    case MenuOptions.MarkIncomplete:
                        {

                            _inputOutputHandler.Clear();
                            await DisplayTasksAsync();
                            var taskId = _inputOutputHandler.ReadPositiveInt("ID задачи для отметки как невыполненной:");
                            await _tasks.UpdateStatusAsync(taskId, false);
                            break;
                        }
                    case MenuOptions.Exit:
                        {
                            if (_inputOutputHandler.ConfirmAction(
                               "Выйти из приложения? (Нажмите enter для подтверждения, любую другую клавишу для отмены)"))
                                {
                                    return;
                                }
                            break;
                        }
                }
            }
        }

        private void PrintMenu()
        {
            _inputOutputHandler.Clear();
            _inputOutputHandler.WriteLine("Менеджер задач");
            _inputOutputHandler.WriteLine($"{(int)MenuOptions.ShowAll}. Показать все задачи");
            _inputOutputHandler.WriteLine($"{(int)MenuOptions.Add}. Добавить задачу");
            _inputOutputHandler.WriteLine($"{(int)MenuOptions.Delete}. Удалить задачу");
            _inputOutputHandler.WriteLine($"{(int)MenuOptions.MarkCompleted}. Отметить как выполненную");
            _inputOutputHandler.WriteLine($"{(int)MenuOptions.MarkIncomplete}. Отметить как невыполненную");
            _inputOutputHandler.WriteLine($"{(int)MenuOptions.Exit}. Выход");
        }
        private async System.Threading.Tasks.Task DisplayTasksAsync()
        {
            _inputOutputHandler.Clear();

            var tasks = await _tasks.GetAllAsync();

            if (tasks == null)
            {
                _inputOutputHandler.WriteLine("Задачи не найдены.");
            }
            else
            {
                foreach (var task in tasks)
                {
                    DisplayTask(task);
                }
            }
        }
        private void DisplayTask(TaskEntity task)
        {
            var status = task.IsCompleted ? "Выполнена" : "В работе";
            _inputOutputHandler.WriteLine($"ID: {task.Id} | {status}");
            _inputOutputHandler.WriteLine($"Название: {task.Title}");
            _inputOutputHandler.WriteLine($"Описание: {task.Description}");
            _inputOutputHandler.WriteLine($"Создана: {task.CreatedAt:dd.MM.yyyy}");
        }
    }
}
