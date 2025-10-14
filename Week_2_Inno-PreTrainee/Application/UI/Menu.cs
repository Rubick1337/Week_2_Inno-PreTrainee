using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week_2_Inno_PreTrainee.Application.Services;
using Week_2_Inno_PreTrainee.Application.Validator;

namespace Week_2_Inno_PreTrainee.Application.UI
{
    public class MenuManager
    {
        private readonly TaskManager _taskManager;

        public MenuManager(TaskManager taskManager)
        {
            _taskManager = taskManager;
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
            Console.Clear();
            Console.WriteLine("Менеджер задач");
            Console.WriteLine("1. Показать все задачи");
            Console.WriteLine("2. Добавить задачу");
            Console.WriteLine("3. Удалить задачу");
            Console.WriteLine("4. Отметить как выполненную");
            Console.WriteLine("5. Отметить как невыполненную");
            Console.WriteLine("0. Выход");

            var choice = InputValidator.ReadMenuChoice("Выберите действие: ", 0, 5);

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
                    if (InputValidator.ConfirmAction("Вы уверены, что хотите выйти? (Нажмите Enter для подтверждения, любую другую клавишу для отмены)"))
                    {
                        return true;
                    }
                    break;
            }

            return false;
        }
    }
}