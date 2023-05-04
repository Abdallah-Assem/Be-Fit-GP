using FluentMigrator;

namespace BeFit_API.Migrations
{
    [Migration(7)]
    public class _007_CreateFeedback : Migration
    {
        public override void Down()
        {

            Delete.Table("Feedback");
        }

        public override void Up()
        {
            Create.Table("Feedback")
                .WithColumn("Id").AsGuid().PrimaryKey()
                .WithColumn("UserId").AsGuid().ForeignKey("User", "Id")
                .WithColumn("Message").AsString().NotNullable()
                .WithColumn("TimeCreated").AsDateTime().NotNullable()
                .WithColumn("Approved").AsBoolean().NotNullable()
                .WithColumn("IsActive").AsBoolean().NotNullable();
        }
    }
}
