using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskEntity = Week_2_Inno_PreTrainee.Core.Entities.Task;

namespace Week_2_Inno_PreTrainee.Application.Interafaces
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskEntity>> GetAllAsync();
        Task CreateAsync(string title, string description);
        Task UpdateStatusAsync(int id, bool isCompleted);
        Task DeleteAsync(int id);
    }
}
