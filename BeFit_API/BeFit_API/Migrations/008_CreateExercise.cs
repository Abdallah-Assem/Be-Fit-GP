using FluentMigrator;

namespace BeFit_API.Migrations
{
    [Migration(8)]
    public class _008_CreateExercise : Migration
    {
        public override void Down()
        {

            Delete.Table("Exercise");
        }
        public override void Up()
        {
            Create.Table("Exercise")
                .WithColumn("Id").AsGuid().PrimaryKey()
                .WithColumn("BodyPart").AsString().NotNullable()
                .WithColumn("Equipment").AsString().NotNullable()
                .WithColumn("GifUrl").AsString().NotNullable()
                .WithColumn("Name").AsString().NotNullable()
                .WithColumn("SetsPlan").AsString().NotNullable()
                .WithColumn("Target").AsString().NotNullable()
                .WithColumn("Plan").AsString().NotNullable()
                .WithColumn("IsActive").AsBoolean().NotNullable();
        }
    }
}
