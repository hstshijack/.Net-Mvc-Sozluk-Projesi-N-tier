namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migaddmessageclass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        MessageId = c.Int(nullable: false, identity: true),
                        Sender = c.String(maxLength: 50),
                        Receiver = c.String(maxLength: 50),
                        Subject = c.String(maxLength: 100),
                        Content = c.String(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MessageId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Messages");
        }
    }
}
