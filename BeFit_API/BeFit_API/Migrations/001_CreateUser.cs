using FluentMigrator;

namespace BeFit_API.Migrations
{
    [Migration(1)]
    public class _001_CreateUser : Migration
    {
        public override void Down()
        {

            Delete.Table("User");
        }

        public override void Up()
        {
            Create.Table("User")
                .WithColumn("Id").AsGuid().PrimaryKey()
                .WithColumn("UserName").AsString().NotNullable().Unique()
                .WithColumn("Password").AsString().NotNullable()
                .WithColumn("Email").AsString().NotNullable().Unique()
                .WithColumn("ProfilePicture").AsString().Nullable()
                .WithColumn("IsActive").AsBoolean().NotNullable();
        }
    }
}
