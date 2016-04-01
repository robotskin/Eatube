namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClientInfoes",
                c => new
                    {
                        clientID = c.Int(nullable: false, identity: true),
                        firstName = c.String(nullable: false),
                        lastName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.clientID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ClientInfoes");
        }
    }
}
