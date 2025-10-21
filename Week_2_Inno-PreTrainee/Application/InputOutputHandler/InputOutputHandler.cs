using System;

namespace Week_2_Inno_PreTrainee.Application.ConsoleHandler
{
    public class InputOutputHandler
    {
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }

        public void WriteError(string message)
        {
            Console.WriteLine(message);
        }

        public void Clear()
        {
            Console.Clear();
        }

        public string ReadLine()
        {
            return Console.ReadLine().Trim();
        }

        public ConsoleKeyInfo ReadKey()
        {
            return Console.ReadKey();
        }

        public int ReadPositiveInt(string prompt)
        {
            while (true)
            {
                WriteLine(prompt);
                var input = ReadLine();

                if (int.TryParse(input, out int result) && result > 0)
                {
                    return result;
                }

                WriteError("Неверный ввод. Введите положительное число.");
            }
        }

        public string ReadPositiveString(string prompt)
        {
            while (true)
            {
                WriteLine(prompt);
                var input = ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    WriteError("Поле не может быть пустым.");
                    continue;
                }
                return input;
            }
        }

        public bool ConfirmAction(string message)
        {
            WriteLine(message);
            ConsoleKeyInfo input = ReadKey();

            if (input.Key == ConsoleKey.Enter)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int ReadMenuChoice(string prompt, int minChoice, int maxChoice)
        {
            while (true)
            {
                WriteLine(prompt);
                var input = ReadLine();

                if (int.TryParse(input, out int choice) && choice >= minChoice && choice <= maxChoice)
                {
                    return choice;
                }

                WriteError($"Неверный выбор. Введите число от {minChoice} до {maxChoice}.");
            }
        }
    }
}