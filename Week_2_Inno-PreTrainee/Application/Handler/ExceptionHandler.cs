using FluentMigrator.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week_2_Inno_PreTrainee.Core.Interfaces;

namespace Week_2_Inno_PreTrainee.Application.Handler
{
    public class ExceptionHandler
    {
        private readonly IOutputService _output;
        public ExceptionHandler(IOutputService output) 
        {
            _output = output;
        }
        public async Task<T> HandleAsyncValue<T>(Task<T> function)
        {
            try
            {
                return await function;
            }
            catch (Exception ex)
            {
                _output.WriteError($"Ошибка: {ex.Message}");
                return default(T);
            }
        }
        public async Task HandleAsyncVoid(Task function)
        {
            try
            {
                await function;
            }
            catch (Exception ex)
            {
                _output.WriteError($"Ошибка: {ex.Message}");
            }
        }
        public void HandleVoid(Action action)
        {
            try
            {
                action();
            }
            catch(Exception ex) 
            {
                _output.WriteError($"Ошибка: {ex.Message}");
            }
        }
        public T HandleValueWithThrow<T>(Func<T> action)
        {
            try
            {
                return action();
            }
            catch (Exception ex)
            {
                _output.WriteError($"Ошибка: {ex.Message}");
                throw;
            }
        }
    }

}
