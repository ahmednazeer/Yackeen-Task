namespace Yackeen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCommentOwner : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "UserID", c => c.Int(nullable: false));
            AddColumn("dbo.Comments", "User_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Comments", "User_Id");
            AddForeignKey("dbo.Comments", "User_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Comments", new[] { "User_Id" });
            DropColumn("dbo.Comments", "User_Id");
            DropColumn("dbo.Comments", "UserID");
        }
    }
}
