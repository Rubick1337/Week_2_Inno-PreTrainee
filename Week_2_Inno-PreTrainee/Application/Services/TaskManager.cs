using System;
using System.Linq;
using TaskEntity = Week_2_Inno_PreTrainee.Core.Entities.Task;
using Week_2_Inno_PreTrainee.Core.Services;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Week_2_Inno_PreTrainee.Application.Validator;
using Week_2_Inno_PreTrainee.Application.Handlers;

namespace Week_2_Inno_PreTrainee.Application.Services
{
    public class TaskManager
    {
        private readonly TaskService _taskService;

        public TaskManager(TaskService taskService)
        {
            _taskService = taskService;
        }

        public async Task ShowAllTasksAsync()
        {
            Console.Clear();
            Console.WriteLine("Все задачи");

            try
            {
                var tasks = await _taskService.GetAllTasksAsync();

                if (tasks == null)
                {
                    Console.WriteLine("Задачи не найдены.");
                }
                else
                {
                    foreach (var taskItem in tasks)
                    {
                        DisplayTask(taskItem);
                    }
                    Console.WriteLine($"Всего задач: {tasks.Count()}");
                }
            }
            catch (Exception ex)
            {
                ErrorHendler.ShowError($"Ошибка: {ex.Message}");
            }

            await WaitForConfirmationAsync();
        }

        public async Task AddNewTaskAsync()
        {
            Console.Clear();
            Console.WriteLine("Добавление задачи");

            var title = InputValidator.ReadPositiveString("Введите название задачи: ");
            var description = InputValidator.ReadPositiveString("Введите описание задачи: ");

            try
            {
                await _taskService.AddTaskAsync(title, description);
                Console.WriteLine("Задача успешно добавлена!");
            }
            catch (Exception ex)
            {
                ErrorHendler.ShowError($"Ошибка: {ex.Message}");
            }

            await WaitForConfirmationAsync();
        }

        public async Task DeleteTaskAsync()
        {
            Console.Clear();
            Console.WriteLine("Удаление задачи");

            try
            {
                var tasks = await _taskService.GetAllTasksAsync();
                if (tasks == null)
                {
                    Console.WriteLine("Нет задач для удаления.");
                    await WaitForConfirmationAsync();
                    return;
                }

                foreach (var taskItem in tasks)
                {
                    DisplayTask(taskItem);
                }

                var taskId = InputValidator.ReadPositiveInt("Введите ID задачи для удаления: ");

                var taskExists = tasks.Any(t => t.Id == taskId);
                if (!taskExists)
                {
                    Console.WriteLine($"Задача с ID {taskId} не найдена.");
                    await WaitForConfirmationAsync();
                    return;
                }

                if (InputValidator.ConfirmAction("Вы уверены, что хотите удалить эту задачу? (Нажмите Enter для подтверждения, любую другую клавишу для отмены)"))
                {
                    await _taskService.DeleteTaskAsync(taskId);
                    Console.WriteLine("Задача успешно удалена!");
                }
                else
                {
                    Console.WriteLine("Удаление отменено.");
                }
            }
            catch (Exception ex)
            {
                ErrorHendler.ShowError($"Ошибка: {ex.Message}");
            }

            await WaitForConfirmationAsync();
        }

        public async Task UpdateTaskStatusAsync(bool isCompleted)
        {
            var statusText = isCompleted ? "Выполненную" : "Невыполненную";
            Console.Clear();
            Console.WriteLine($"Отметка задачи как {statusText}");

            try
            {
                var tasks = await _taskService.GetAllTasksAsync();
                if (tasks == null)
                {
                    Console.WriteLine("Нет задач для обновления.");
                    await WaitForConfirmationAsync();
                    return;
                }

                foreach (var taskItem in tasks)
                {
                    DisplayTask(taskItem);
                }

                var taskId = InputValidator.ReadPositiveInt("Введите ID задачи: ");

                var foundTask = tasks.FirstOrDefault(t => t.Id == taskId);
                if (foundTask == null)
                {
                    Console.WriteLine($"Задача с ID {taskId} не найдена.");
                }
                else if (foundTask.IsCompleted == isCompleted)
                {
                    var currentStatus = isCompleted ? "уже выполнена" : "уже не выполнена";
                    Console.WriteLine($"Задача {currentStatus}.");
                }
                else
                {
                    if (InputValidator.ConfirmAction($"Вы уверены, что хотите отметить задачу как {(isCompleted ? "выполненную" : "невыполненную")}? (Нажмите Enter для подтверждения, любую другую клавишу для отмены)"))
                    {
                        await _taskService.UpdateTaskStatusAsync(taskId, isCompleted);
                        var status = isCompleted ? "выполненной" : "невыполненной";
                        Console.WriteLine($"Задача отмечена как {status}!");
                    }
                    else
                    {
                        Console.WriteLine("Действие отменено.");
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorHendler.ShowError($"Ошибка: {ex.Message}");
            }

            await WaitForConfirmationAsync();
        }

        private void DisplayTask(TaskEntity task)
        {
            var status = task.IsCompleted ? "Выполнена" : "В работе";
            Console.WriteLine($"ID: {task.Id} | {status}");
            Console.WriteLine($"Название: {task.Title}");
            Console.WriteLine($"Описание: {task.Description}");
            Console.WriteLine($"Создана: {task.CreatedAt:dd.MM.yyyy HH:mm}");
        }

        private async Task WaitForConfirmationAsync()
        {
            Console.WriteLine("\nНажмите любую клавишу для продолжения...");
            await Task.Run(() => Console.ReadKey());
        }
    }
}