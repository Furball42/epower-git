namespace ePower.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrganizationInformations",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Database = c.String(),
                        Server = c.String(),
                        User = c.String(),
                        Password = c.String(),
                        UserInformation_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserInformations", t => t.UserInformation_Id)
                .Index(t => t.UserInformation_Id);
            
            CreateTable(
                "dbo.UserInformations",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Username = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrganizationInformations", "UserInformation_Id", "dbo.UserInformations");
            DropIndex("dbo.OrganizationInformations", new[] { "UserInformation_Id" });
            DropTable("dbo.UserInformations");
            DropTable("dbo.OrganizationInformations");
        }
    }
}
