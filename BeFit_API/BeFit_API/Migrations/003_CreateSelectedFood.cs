using FluentMigrator;

namespace BeFit_API.Migrations
{
    [Migration(3)]
    public class _003_CreateSelectedFood : Migration
    {
        public override void Down()
        {
            Delete.Table("SelectedFood");
        }

        public override void Up()
        {
            Create.Table("SelectedFood")
                .WithColumn("Id").AsGuid().PrimaryKey()
                .WithColumn("UserId").AsGuid().ForeignKey("User", "Id")
                .WithColumn("FoodName").AsString().NotNullable()
                .WithColumn("Weight").AsDouble().NotNullable()
                .WithColumn("Quantity").AsInt32().NotNullable()
                .WithColumn("Calories").AsDouble().NotNullable()
                .WithColumn("Fats").AsDouble().NotNullable()
                .WithColumn("Carbs").AsDouble().NotNullable()
                .WithColumn("Protein").AsDouble().NotNullable()
                .WithColumn("Meal").AsString().NotNullable()
                .WithColumn("TimeCreated").AsDateTime().NotNullable()
                .WithColumn("IsActive").AsBoolean().NotNullable();
        }
    }
}
