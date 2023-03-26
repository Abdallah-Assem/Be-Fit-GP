using FluentMigrator;

namespace BeFit_API.Migrations
{
    //[Migration(4)]
    public class _004_CreateUser_SelectedFood : Migration
    {
        public override void Down()
        {
            Delete.Table("User_SelectedFood");
        }

        public override void Up()
        {
            Create.Table("User_SelectedFood")
                .WithColumn("Id").AsGuid().PrimaryKey()
                .WithColumn("SelectedFoodId").AsGuid().ForeignKey("SelectedFood", "Id")
                .WithColumn("UserId").AsGuid().ForeignKey("User", "Id")
                .WithColumn("RemainingCalories").AsDouble().NotNullable()
                .WithColumn("RemainingFats").AsDouble().NotNullable()
                .WithColumn("RemainingCarbs").AsDouble().NotNullable()
                .WithColumn("RemainingProtein").AsDouble().NotNullable();
        }
    }
}
