namespace ApiDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClientKey",
                c => new
                    {
                        ClientKeyID = c.Int(nullable: false, identity: true),
                        CompanyID = c.Int(nullable: false),
                        ClientID = c.String(),
                        ClientSecret = c.String(),
                        CreateOn = c.DateTime(nullable: false),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClientKeyID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ClientKey");
        }
    }
}
