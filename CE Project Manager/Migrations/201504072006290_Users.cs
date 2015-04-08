namespace CE_Project_Manager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Users : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Logs",
                c => new
                    {
                        LogId = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false, precision: 0),
                        Text = c.String(maxLength: 2048, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.LogId);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        MessageId = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false, precision: 0),
                        Text = c.String(maxLength: 1024, storeType: "nvarchar"),
                        User_UserId = c.Int(),
                        Recipient_UserId = c.Int(),
                        Sender_UserId = c.Int(),
                        User_UserId1 = c.Int(),
                    })
                .PrimaryKey(t => t.MessageId)
                .ForeignKey("dbo.Users", t => t.User_UserId)
                .ForeignKey("dbo.Users", t => t.Recipient_UserId)
                .ForeignKey("dbo.Users", t => t.Sender_UserId)
                .ForeignKey("dbo.Users", t => t.User_UserId1)
                .Index(t => t.User_UserId)
                .Index(t => t.Recipient_UserId)
                .Index(t => t.Sender_UserId)
                .Index(t => t.User_UserId1);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Login = c.String(unicode: false),
                        Name = c.String(unicode: false),
                        Surname = c.String(unicode: false),
                        Password = c.String(unicode: false),
                        Logged = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.News",
                c => new
                    {
                        NewsId = c.Int(nullable: false, identity: true),
                        Text = c.String(maxLength: 1024, storeType: "nvarchar"),
                        DateTime = c.DateTime(nullable: false, precision: 0),
                        User_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.NewsId)
                .ForeignKey("dbo.Users", t => t.User_UserId)
                .Index(t => t.User_UserId);
            
            CreateTable(
                "dbo.UserPrivileges",
                c => new
                    {
                        PrivilegeId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 45, storeType: "nvarchar"),
                        Description = c.String(maxLength: 255, storeType: "nvarchar"),
                        User_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.PrivilegeId)
                .ForeignKey("dbo.Users", t => t.User_UserId)
                .Index(t => t.User_UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Messages", "User_UserId1", "dbo.Users");
            DropForeignKey("dbo.Messages", "Sender_UserId", "dbo.Users");
            DropForeignKey("dbo.Messages", "Recipient_UserId", "dbo.Users");
            DropForeignKey("dbo.UserPrivileges", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.News", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.Messages", "User_UserId", "dbo.Users");
            DropIndex("dbo.UserPrivileges", new[] { "User_UserId" });
            DropIndex("dbo.News", new[] { "User_UserId" });
            DropIndex("dbo.Messages", new[] { "User_UserId1" });
            DropIndex("dbo.Messages", new[] { "Sender_UserId" });
            DropIndex("dbo.Messages", new[] { "Recipient_UserId" });
            DropIndex("dbo.Messages", new[] { "User_UserId" });
            DropTable("dbo.UserPrivileges");
            DropTable("dbo.News");
            DropTable("dbo.Users");
            DropTable("dbo.Messages");
            DropTable("dbo.Logs");
        }
    }
}
