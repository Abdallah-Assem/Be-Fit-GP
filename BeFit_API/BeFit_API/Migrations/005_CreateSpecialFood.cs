using FluentMigrator;

namespace BeFit_API.Migrations
{
    [Migration(5)]
    public class _005_CreateSpecialFood : Migration
    {
        public override void Down()
        {
            Delete.Table("SpecialFood");
        }

        public override void Up()
        {
            Create.Table("SpecialFood")
                .WithColumn("Id").AsGuid().PrimaryKey()
                .WithColumn("UserId").AsGuid().ForeignKey("User", "Id")
                .WithColumn("Name").AsString().NotNullable()
                .WithColumn("Calories").AsDouble().NotNullable()
                .WithColumn("Fats").AsDouble().NotNullable()
                .WithColumn("Carbs").AsDouble().NotNullable()
                .WithColumn("Protein").AsDouble().NotNullable()
                .WithColumn("IsActive").AsBoolean().NotNullable();

     
        }
    }
}
