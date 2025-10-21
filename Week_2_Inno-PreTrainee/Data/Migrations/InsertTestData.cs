using FluentMigrator;

namespace Week_2_Inno_PreTrainee.Infrastructure.Migrations
{
    [Migration(20251010)]
    public class InsertTestData: Migration
    {
     
        public override void Up()
        {
            Insert.IntoTable("Tasks").InSchema("dbo")
                .Row(new { Title = "Задание 1 неделя 1", Description = "Консольный кулькулятор", IsCompleted = true, CreatedAt = DateTime.Now })
                .Row(new { Title = "Задание 2 неделя 1", Description = "Асихронное приложение", IsCompleted = true, CreatedAt = DateTime.Now })
                .Row(new { Title = "Задание 3 неделя 2", Description = "Консольный кулькулятор", IsCompleted = false, CreatedAt = DateTime.Now });
        }
        public override void Down() 
        {
            Delete.FromTable("Tasks").AllRows();
        }
    }
}
