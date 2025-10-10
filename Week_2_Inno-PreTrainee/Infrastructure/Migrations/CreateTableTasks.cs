using FluentMigrator;

namespace Week_2_Inno_PreTrainee.Infrastructure.Migrations

{

    [Migration(20251010)]

    public class CreateTableTasks : Migration

    {

        public override void Up()

        {
            Create.Table("Tasks")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Title").AsString().NotNullable()
                .WithColumn("Description").AsString().NotNullable()
                .WithColumn("IsCompleted").AsBoolean().NotNullable().WithDefaultValue(false)
                .WithColumn("CreatedAt").AsDateTime2().NotNullable().WithDefaultValue(DateTime.Now);
        }

        public override void Down()

        {
            Delete.Table("Tasks");
        }

    }

}