namespace Task.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MDB : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reviews", "Article_ID", "dbo.Articles");
            DropIndex("dbo.Reviews", new[] { "Article_ID" });
            DropColumn("dbo.Reviews", "Article_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reviews", "Article_ID", c => c.Int());
            CreateIndex("dbo.Reviews", "Article_ID");
            AddForeignKey("dbo.Reviews", "Article_ID", "dbo.Articles", "ID");
        }
    }
}
