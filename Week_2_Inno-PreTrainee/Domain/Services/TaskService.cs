using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Week_2_Inno_PreTrainee.Application.Interafaces;
using Week_2_Inno_PreTrainee.Data.Interfaces;
using TaskEntity = Week_2_Inno_PreTrainee.Core.Entities.Task;

namespace Week_2_Inno_PreTrainee.Core.Services
{
    public class TaskService : ITaskService, IDisposable
    {
        private readonly IRepository<TaskEntity> _taskRepository;

        public TaskService(IRepository<TaskEntity> taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<IEnumerable<TaskEntity>> GetAllAsync()
        {
            return await _taskRepository.GetAllAsync() ?? new List<TaskEntity>();
        }

        public async Task CreateAsync(string title, string description)
        {
            var entity = new TaskEntity
            {
                Title = title.Trim(),
                Description = description?.Trim(),
                IsCompleted = false,
                CreatedAt = DateTime.Now
            };

            await _taskRepository.CreateAsync(entity);
        }

        public Task UpdateStatusAsync(int id, bool isCompleted)
        {
            return _taskRepository.UpdateStatusAsync(id, isCompleted);
        }

        public Task DeleteAsync(int id)
        {
            return _taskRepository.DeleteAsync(id);
        }

        public void Dispose()
        {
            _taskRepository?.Dispose();
        }
    }
}
