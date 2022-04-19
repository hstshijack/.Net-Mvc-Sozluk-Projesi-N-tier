namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migaddadminclass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminId = c.Int(nullable: false, identity: true),
                        UserName = c.String(maxLength: 50),
                        Password = c.String(maxLength: 50),
                        Role = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.AdminId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Admins");
        }
    }
}
