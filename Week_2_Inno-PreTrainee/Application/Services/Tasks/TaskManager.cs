using System;
using System.Linq;
using TaskEntity = Week_2_Inno_PreTrainee.Core.Entities.Task;
using Week_2_Inno_PreTrainee.Core.Services;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Week_2_Inno_PreTrainee.Application.Validator;
using Week_2_Inno_PreTrainee.Application.Handler;
using Week_2_Inno_PreTrainee.Core.Interfaces;

namespace Week_2_Inno_PreTrainee.Application.Services.Tasks
{
    public class TaskManager
    {
        private readonly TaskOperationService _operationService;
        private readonly TaskDisplayService _displayService;
        private readonly UserInteractionTaskService _interactionTaskService;
        private readonly IOutputService _outputService;

        public TaskManager(
            TaskOperationService operationService,
            TaskDisplayService displayService,
            UserInteractionTaskService interactionTaskService,
            IOutputService outputService)
        {
            _operationService = operationService;
            _displayService = displayService;
            _interactionTaskService = interactionTaskService;
            _outputService = outputService;
        }

        public async Task ShowAllTasksAsync()
        {
            _displayService.DisplayHeader("Все задачи");

            var tasks = await _operationService.GetAllTasksAsync();

            if (tasks == null || !tasks.Any())
            {
                _outputService.WriteError("Задачи не найдены.");
            }
            else
            {
                _displayService.DisplayTaskList(tasks);
            }

           _interactionTaskService.WaitForConfirmation();
        }

        public async Task AddNewTaskAsync()
        {
            _displayService.DisplayHeader("Добавление задачи");

            var title = _interactionTaskService.ReadTitle();
            var description = _interactionTaskService.ReadDescription();

            await _operationService.AddTaskAsync(title, description);
            _outputService.WriteLine("Задача успешно добавлена!");

            _interactionTaskService.WaitForConfirmation();
        }

        public async Task DeleteTaskAsync()
        {
            _displayService.DisplayHeader("Удаление задачи");

            var tasks = await _operationService.GetAllTasksAsync();

            if (!tasks.Any())
            {
                _outputService.WriteLine("Нет задач для удаления.");
                _interactionTaskService.WaitForConfirmation(); ;
                return;
            }

            _displayService.DisplayTaskList(tasks);
            await ProcessTaskDeletion(tasks);
        }

        private async Task ProcessTaskDeletion(IEnumerable<TaskEntity> tasks)
        {
            var taskId = _interactionTaskService.ReadTaskId();

            if (!tasks.Any(t => t.Id == taskId))
            {
                _outputService.WriteError($"Задача с ID {taskId} не найдена.");
            }
            else if (_interactionTaskService.ConfirmAction("Вы уверены, что хотите удалить эту задачу?"))
            {
                await _operationService.DeleteTaskAsync(taskId);
                _outputService.WriteLine("Задача успешно удалена!");
            }
            else
            {
                _outputService.WriteLine("Удаление отменено.");
            }

            _interactionTaskService.WaitForConfirmation();
        }

        public async Task UpdateTaskStatusAsync(bool isCompleted)
        {
            var statusText = isCompleted ? "Выполненную" : "Невыполненную";
            _displayService.DisplayHeader($"Отметка задачи как {statusText}");

            var tasks = await _operationService.GetAllTasksAsync();

            if (!tasks.Any())
            {
                _outputService.WriteLine("Нет задач для обновления.");
                _interactionTaskService.WaitForConfirmation();
                return;
            }

            _displayService.DisplayTaskList(tasks);
            await ProcessStatusUpdate(tasks, isCompleted);
        }

        private async Task ProcessStatusUpdate(IEnumerable<TaskEntity> tasks, bool isCompleted)
        {
            var taskId = _interactionTaskService.ReadTaskId();
            var foundTask = tasks.FirstOrDefault(t => t.Id == taskId);

            if (foundTask == null)
            {
                _outputService.WriteError($"Задача с ID {taskId} не найдена.");
            }
            else if (foundTask.IsCompleted == isCompleted)
            {
                var currentStatus = isCompleted ? "уже выполнена" : "уже не выполнена";
                _outputService.WriteLine($"Задача {currentStatus}.");
            }
            else
            {
                await ConfirmAndUpdateStatus(taskId, isCompleted);
            }

            _interactionTaskService.WaitForConfirmation();
        }

        private async Task ConfirmAndUpdateStatus(int taskId, bool isCompleted)
        {
            var actionText = isCompleted ? "выполненную" : "невыполненную";
            if (_interactionTaskService.ConfirmAction($"Вы уверены, что хотите отметить задачу как {actionText}?"))
            {
                await _operationService.UpdateTaskStatusAsync(taskId, isCompleted);
                var status = isCompleted ? "выполненной" : "невыполненной";
                _outputService.WriteLine($"Задача отмечена как {status}!");
            }
            else
            {
                _outputService.WriteLine("Действие отменено.");
            }
        }
    }
}