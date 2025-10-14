using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week_2_Inno_PreTrainee.Application.Handlers;

namespace Week_2_Inno_PreTrainee.Application.Validator
{
    public class InputValidator
    {
        public static int ReadPositiveInt(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                var input = Console.ReadLine();

                if (int.TryParse(input, out int result) && result > 0)
                {
                    return result;
                }

                ErrorHendler.ShowError("Неверный ввод. Введите положительное число.");
            }
        }
        public static string ReadPositiveString(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                var input = Console.ReadLine().Trim();

                if (string.IsNullOrWhiteSpace(input))
                {
                    ErrorHendler.ShowError("Поле не может быть пустым.");
                    continue;
                }
                return input;
            }
        }
        public static bool ConfirmAction(string message)
        {
            Console.WriteLine(message);

            ConsoleKeyInfo input = Console.ReadKey();

            if (input.Key == ConsoleKey.Enter)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static int ReadMenuChoice(string prompt, int minChoice, int maxChoice)
        {
            while (true)
            {
                Console.Write(prompt);
                var input = Console.ReadLine();

                if (int.TryParse(input, out int choice) && choice >= minChoice && choice <= maxChoice)
                {
                    return choice;
                }

                ErrorHendler.ShowError($"Неверный выбор. Введите число от {minChoice} до {maxChoice}.");
            }
        }

    }
}
