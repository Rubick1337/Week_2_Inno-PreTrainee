using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week_2_Inno_PreTrainee.Application.Services.Tasks;
using Week_2_Inno_PreTrainee.Application.Validator;
using Week_2_Inno_PreTrainee.Core.Interfaces;

namespace Week_2_Inno_PreTrainee.Application.UI
{
    public class MenuManager
    {
        private readonly TaskManager _taskManager;
        private readonly IOutputService _output;
        private readonly InputValidator _inputValidator;

        public MenuManager(TaskManager taskManager, IOutputService output, InputValidator inputValidator)
        {
            _taskManager = taskManager;
            _output = output;
            _inputValidator = inputValidator;
        }

        public async Task RunAsync()  
        {
            bool shouldExit = false;

            while (!shouldExit)
            {
                shouldExit = await ShowMainMenuAsync();  
            }
        }

        private async Task<bool> ShowMainMenuAsync()  
        {
            _output.Clear();
            _output.WriteLine("Менеджер задач");
            _output.WriteLine("1. Показать все задачи");
            _output.WriteLine("2. Добавить задачу");
            _output.WriteLine("3. Удалить задачу");
            _output.WriteLine("4. Отметить как выполненную");
            _output.WriteLine("5. Отметить как невыполненную");
            _output.WriteLine("0. Выход");

            var choice = _inputValidator.ReadMenuChoice("Выберите действие: ", 0, 5);

            switch (choice)
            {
                case 1:
                    await _taskManager.ShowAllTasksAsync();  
                    break;
                case 2:
                    await _taskManager.AddNewTaskAsync();    
                    break;
                case 3:
                    await _taskManager.DeleteTaskAsync();    
                    break;
                case 4:
                    await _taskManager.UpdateTaskStatusAsync(true);  
                    break;
                case 5:
                    await _taskManager.UpdateTaskStatusAsync(false); 
                    break;
                case 0:
                    if (_inputValidator.ConfirmAction("Вы уверены, что хотите выйти? (Нажмите Enter для подтверждения, любую другую клавишу для отмены)"))
                    {
                        return true;
                    }
                    break;
            }

            return false;
        }
    }
}