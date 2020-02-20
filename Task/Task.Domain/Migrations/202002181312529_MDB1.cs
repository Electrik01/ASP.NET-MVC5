namespace Task.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MDB1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TagArticles",
                c => new
                    {
                        Tag_Id = c.Int(nullable: false),
                        Article_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_Id, t.Article_ID })
                .ForeignKey("dbo.Tags", t => t.Tag_Id, cascadeDelete: true)
                .ForeignKey("dbo.Articles", t => t.Article_ID, cascadeDelete: true)
                .Index(t => t.Tag_Id)
                .Index(t => t.Article_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TagArticles", "Article_ID", "dbo.Articles");
            DropForeignKey("dbo.TagArticles", "Tag_Id", "dbo.Tags");
            DropIndex("dbo.TagArticles", new[] { "Article_ID" });
            DropIndex("dbo.TagArticles", new[] { "Tag_Id" });
            DropTable("dbo.TagArticles");
        }
    }
}
