using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week_2_Inno_PreTrainee.Application.Handler;
using Week_2_Inno_PreTrainee.Core.Services;
using TaskEntity = Week_2_Inno_PreTrainee.Core.Entities.Task;

namespace Week_2_Inno_PreTrainee.Application.Services.Tasks
{
    public class TaskOperationService
    {
        private readonly TaskService _taskService;
        private readonly ExceptionHandler _exceptionHandler;

        public TaskOperationService(
            TaskService taskService,
            ExceptionHandler exceptionHandler)
        {
            _taskService = taskService;
            _exceptionHandler = exceptionHandler;
        }

        public async Task<IEnumerable<TaskEntity>> GetAllTasksAsync()
        {
            return await _exceptionHandler.HandleAsyncValue(_taskService.GetAllTasksAsync());
        }

        public async Task AddTaskAsync(string title, string description)
        {
            await _exceptionHandler.HandleAsyncVoid(_taskService.AddTaskAsync(title, description));
        }

        public async Task DeleteTaskAsync(int taskId)
        {
            await _exceptionHandler.HandleAsyncVoid(_taskService.DeleteTaskAsync(taskId));
        }

        public async Task UpdateTaskStatusAsync(int taskId, bool isCompleted)
        {
            await _exceptionHandler.HandleAsyncVoid(_taskService.UpdateTaskStatusAsync(taskId, isCompleted));
        }
    }
}
