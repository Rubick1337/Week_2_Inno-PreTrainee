using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week_2_Inno_PreTrainee.Application.Services;
using Week_2_Inno_PreTrainee.Core.Interfaces;

namespace Week_2_Inno_PreTrainee.Application.Validator
{
    public class InputValidator
    {
        private readonly IOutputService _output;
        private readonly IInputService _input;
        public InputValidator(IOutputService output,IInputService input) 
        {
            _output = output;
            _input = input;
        }
        public int ReadPositiveInt(string prompt)
        {
            while (true)
            {
                _output.WriteLine(prompt);
                var input = _input.ReadLine();

                if (int.TryParse(input, out int result) && result > 0)
                {
                    return result;
                }

                _output.WriteError("Неверный ввод. Введите положительное число.");
            }
        }
        public string ReadPositiveString(string prompt)
        {
            while (true)
            {
                _output.WriteLine(prompt);
                var input = _input.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    _output.WriteError("Поле не может быть пустым.");
                    continue;
                }
                return input;
            }
        }
        public  bool ConfirmAction(string message)
        {
            _output.WriteLine(message);

            ConsoleKeyInfo input = _input.ReadKey();

            if (input.Key == ConsoleKey.Enter)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public  int ReadMenuChoice(string prompt, int minChoice, int maxChoice)
        {
            while (true)
            {
                _output.WriteLine(prompt);
                var input = _input.ReadLine();

                if (int.TryParse(input, out int choice) && choice >= minChoice && choice <= maxChoice)
                {
                    return choice;
                }

                _output.WriteError($"Неверный выбор. Введите число от {minChoice} до {maxChoice}.");
            }
        }

    }
}
