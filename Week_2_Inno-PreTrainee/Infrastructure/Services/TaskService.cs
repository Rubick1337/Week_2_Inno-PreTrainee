using System;
using System.Collections.Generic;
using TaskEntity = Week_2_Inno_PreTrainee.Core.Entities.Task;
using Week_2_Inno_PreTrainee.Core.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Week_2_Inno_PreTrainee.Core.Services
{
    public class TaskService : IDisposable
    {
        private readonly IRepository<TaskEntity> _taskRepository;

        public TaskService(IRepository<TaskEntity> taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task < IEnumerable<TaskEntity>> GetAllTasksAsync()
        {
            try
            {
                return await _taskRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Ошибка при получении задач: " + ex.Message, ex);
            }
        }

        public async Task AddTaskAsync(string title, string description)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("Название задачи не может быть пустым");
            }
                
            try
            {
                var task = new TaskEntity
                {
                    Title = title.Trim(),
                    Description = description?.Trim(),
                    IsCompleted = false,
                    CreatedAt = DateTime.Now
                };

                await _taskRepository.CreateAsync(task);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Ошибка при создании задачи: " + ex.Message, ex);
            }
        }

        public async Task DeleteTaskAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID должен быть больше 0");
            }

            try
            {
                await _taskRepository.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Ошибка при удалении задачи {id}: " + ex.Message, ex);
            }
        }

        public async Task UpdateTaskStatusAsync(int id, bool isCompleted)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID должен быть больше 0");
            }
               
            try
            {
                await _taskRepository.UpdateStatusAsync(id, isCompleted);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Ошибка при обновлении задачи {id}: " + ex.Message, ex);
            }
        }

        public void Dispose()
        {
            _taskRepository?.Dispose();
        }
    }
}