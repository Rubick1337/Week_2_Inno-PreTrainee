using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week_2_Inno_PreTrainee.Data.Interfaces;

namespace Week_2_Inno_PreTrainee.Infrastructure.Repository
{
    internal abstract class RepositoryBase<T> : IRepository<T> where T : class
    {
        protected readonly IDbConnection _connection;
        protected readonly string _tableName;

        public  RepositoryBase (IDbConnection connection, string tableName)
        {
            _connection = connection;
            _tableName = tableName;
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var sql = $"SELECT * FROM {_tableName}";
            return  await _connection.QueryAsync<T>(sql);
        }
        public abstract Task CreateAsync(T item);
        public abstract Task UpdateStatusAsync(int id, bool isCompleted);

        public async Task DeleteAsync(int id)
        {
            var sql = $"DELETE FROM {_tableName} WHERE Id = @id";
            await _connection.ExecuteAsync(sql, new { id });
        }
        public void Dispose()
        {
            _connection?.Dispose();
        }
    }
}
