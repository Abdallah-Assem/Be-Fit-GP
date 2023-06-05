using FluentMigrator;

namespace BeFit_API.Migrations
{
    [Migration(2)]
    public class _002_CreateUserMacros : Migration
    {
        public override void Down()
        {
            Delete.Table("UserMacros");
        }

        public override void Up()
        {
            Create.Table("UserMacros")
                .WithColumn("Id").AsGuid().PrimaryKey()
                .WithColumn("UserId").AsGuid().ForeignKey("User", "Id").Unique()
                .WithColumn("Height").AsDouble().NotNullable()
                .WithColumn("Weight").AsDouble().NotNullable()
                .WithColumn("Age").AsInt32().NotNullable()
                .WithColumn("DateOfBirth").AsDate().NotNullable()
                .WithColumn("Gender").AsString().NotNullable()
                .WithColumn("Goal").AsString().NotNullable()
                .WithColumn("ActivityLevel").AsString().NotNullable()
                .WithColumn("Disease").AsString().NotNullable()
                .WithColumn("DailyCalories").AsDouble().NotNullable()
                .WithColumn("DailyFats").AsDouble().NotNullable()
                .WithColumn("DailyCarbs").AsDouble().NotNullable()
                .WithColumn("DailyProtein").AsDouble().NotNullable()
                .WithColumn("IsActive").AsBoolean().NotNullable();
        }
    }
}
