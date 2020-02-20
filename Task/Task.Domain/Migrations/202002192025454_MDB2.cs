namespace Task.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MDB2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Articles", "IsShow", c => c.Boolean(nullable: false));
            AddColumn("dbo.Articles", "IsDel", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Articles", "IsDel");
            DropColumn("dbo.Articles", "IsShow");
        }
    }
}
