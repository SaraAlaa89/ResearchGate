namespace ResearchGateProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Papers", "AuthorID");
            AddForeignKey("dbo.Papers", "AuthorID", "dbo.Users", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Papers", "AuthorID", "dbo.Users");
            DropIndex("dbo.Papers", new[] { "AuthorID" });
            DropColumn("dbo.Users", "Discriminator");
        }
    }
}
