namespace Yackeen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class final : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "ArticleID", "dbo.Articles");
            DropForeignKey("dbo.Comments", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Comments", new[] { "ArticleID" });
            DropIndex("dbo.Comments", new[] { "User_Id" });
            AddColumn("dbo.Comments", "Username", c => c.String());
            DropColumn("dbo.Comments", "UserID");
            DropColumn("dbo.Comments", "User_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comments", "User_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Comments", "UserID", c => c.Int(nullable: false));
            DropColumn("dbo.Comments", "Username");
            CreateIndex("dbo.Comments", "User_Id");
            CreateIndex("dbo.Comments", "ArticleID");
            AddForeignKey("dbo.Comments", "User_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Comments", "ArticleID", "dbo.Articles", "ID", cascadeDelete: true);
        }
    }
}
