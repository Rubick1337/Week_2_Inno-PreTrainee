using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week_2_Inno_PreTrainee.Core.Interfaces;
using TaskEntity = Week_2_Inno_PreTrainee.Core.Entities.Task;

namespace Week_2_Inno_PreTrainee.Application.Services.Tasks
{
    public class TaskDisplayService
    {
        private readonly IOutputService _output;

        public TaskDisplayService(IOutputService output)
        {
            _output = output;
        }

        public void DisplayTask(TaskEntity task)
        {
            var status = task.IsCompleted ? "Выполнена" : "В работе";
            _output.WriteLine($"ID: {task.Id} | {status}");
            _output.WriteLine($"Название: {task.Title}");
            _output.WriteLine($"Описание: {task.Description}");
            _output.WriteLine($"Создана: {task.CreatedAt:dd.MM.yyyy}");
        }

        public void DisplayTaskList(IEnumerable<TaskEntity> tasks)
        {
            foreach (var task in tasks)
            {
                DisplayTask(task);
            }
            _output.WriteLine($"Всего задач: {tasks.Count()}");
        }

        public void DisplayHeader(string title)
        {
            _output.Clear();
            _output.WriteLine(title);
        }
    }
}
