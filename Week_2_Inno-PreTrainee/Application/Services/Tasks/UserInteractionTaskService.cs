using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week_2_Inno_PreTrainee.Application.Validator;
using Week_2_Inno_PreTrainee.Core.Interfaces;

namespace Week_2_Inno_PreTrainee.Application.Services.Tasks
{
    public class UserInteractionTaskService
    {
        private readonly IOutputService _output;
        private readonly IInputService _input;
        private readonly InputHandler _validator;

        public UserInteractionTaskService(
            IOutputService output,
            IInputService input,
            InputHandler validator)
        {
            _output = output;
            _input = input;
            _validator = validator;
        }

        public void WaitForConfirmation()
        {
            _output.WriteLine("\nНажмите любую клавишу для продолжения...");
            _input.ReadKey();
        }

        public string ReadTitle()
        {
            return _validator.ReadPositiveString("Введите название задачи: ");
        }

        public string ReadDescription()
        {
            return _validator.ReadPositiveString("Введите описание задачи: ");
        }

        public int ReadTaskId()
        {
            return _validator.ReadPositiveInt("Введите ID задачи: ");
        }

        public bool ConfirmAction(string message)
        {
            return _validator.ConfirmAction(message);
        }

    }
}
