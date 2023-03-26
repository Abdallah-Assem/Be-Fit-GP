using FluentMigrator;

namespace BeFit_API.Migrations
{
    [Migration (6)]
    public class _006_SeedingUser : Migration
    {
        public override void Down()
        {
            
        }

        public override void Up()
        {
            Insert.IntoTable(tableName: "User").Row(new
            {
                Id = Guid.Parse("539b1e75-f5f7-487c-87f5-080e23e20b76")
                , UserName = "Abdallah"
                , Password = "Assem"
                , Email = "abdallah@gmail.com"
                , IsActive = true
                
            });

        }
    }
}
