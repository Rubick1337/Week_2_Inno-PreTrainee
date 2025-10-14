using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using TaskEntity = Week_2_Inno_PreTrainee.Core.Entities.Task;
using Week_2_Inno_PreTrainee.Core.Interfaces;

namespace Week_2_Inno_PreTrainee.Infrastructure.Repository
{
    internal class SqlServerTaskRepository :RepositoryBase<TaskEntity> , IRepository<TaskEntity>
    {
        public SqlServerTaskRepository(IDbConnection connection) : base( connection,"Tasks")
        {

        }
        public override async Task CreateAsync(TaskEntity item)
        {
            var sql = "INSERT INTO Tasks (Title, Description, IsCompleted, CreatedAt) VALUES (@Title, @Description, @IsCompleted, @CreatedAt)";
            await _connection.ExecuteAsync(sql, item);
        }
        public override async Task UpdateStatusAsync(int id, bool isCompleted)
        {
            var sql = "UPDATE Tasks SET IsCompleted = @IsCompleted WHERE Id = @Id";
            await _connection.ExecuteAsync(sql, new { Id = id, IsCompleted = isCompleted });
        }
    }
}
