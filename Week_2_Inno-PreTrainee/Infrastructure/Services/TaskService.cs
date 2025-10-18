using System;
using System.Collections.Generic;
using TaskEntity = Week_2_Inno_PreTrainee.Core.Entities.Task;
using Week_2_Inno_PreTrainee.Core.Interfaces;
using System.Linq;
using System.Threading.Tasks;
using Week_2_Inno_PreTrainee.Application.Handler;

namespace Week_2_Inno_PreTrainee.Core.Services
{
    public class TaskService : IDisposable
    {
        private readonly IRepository<TaskEntity> _taskRepository;
        private readonly ExceptionHandler _exceptionHandler;

        public TaskService
            (IRepository<TaskEntity> taskRepository, 
            ExceptionHandler exceptionHandler
            )
        {
            _exceptionHandler = exceptionHandler;
            _taskRepository = taskRepository;
        }

        public async Task < IEnumerable<TaskEntity>> GetAllTasksAsync()
        {
            return await _exceptionHandler.HandleAsyncValue(_taskRepository.GetAllAsync())
                   ?? new List<TaskEntity>();
        }

        public async Task AddTaskAsync(string title, string description)
        {

                var task = new TaskEntity
                {
                    Title = title.Trim(),
                    Description = description?.Trim(),
                    IsCompleted = false,
                    CreatedAt = DateTime.Now
                };

              await _exceptionHandler.HandleAsyncVoid(_taskRepository.CreateAsync(task));
        }

        public async Task DeleteTaskAsync(int id)
        {
            await _exceptionHandler.HandleAsyncVoid(_taskRepository.DeleteAsync(id));
        }

        public async Task UpdateTaskStatusAsync(int id, bool isCompleted)
        {
            await _exceptionHandler.HandleAsyncVoid(_taskRepository.UpdateStatusAsync(id, isCompleted));
        }

        public void Dispose()
        {
            _taskRepository?.Dispose();
        }
    }
}