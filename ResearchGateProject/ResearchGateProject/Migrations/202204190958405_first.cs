namespace ResearchGateProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Catagories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        type = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Papers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        like = c.Boolean(nullable: false),
                        dislike = c.Boolean(nullable: false),
                        content = c.String(),
                        Date = c.DateTime(nullable: false),
                        catagory = c.String(),
                        AuthorID = c.Int(nullable: false),
                        catagoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Catagories", t => t.catagoryID, cascadeDelete: true)
                .Index(t => t.catagoryID);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        content = c.String(),
                        paperID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Papers", t => t.paperID, cascadeDelete: true)
                .Index(t => t.paperID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        email = c.String(),
                        password = c.String(),
                        adderss = c.String(),
                        age = c.Int(nullable: false),
                        university = c.String(),
                        department = c.String(),
                        phoneNumber = c.String(),
                        image = c.String(),
                        role = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Papers", "catagoryID", "dbo.Catagories");
            DropForeignKey("dbo.Comments", "paperID", "dbo.Papers");
            DropIndex("dbo.Comments", new[] { "paperID" });
            DropIndex("dbo.Papers", new[] { "catagoryID" });
            DropTable("dbo.Users");
            DropTable("dbo.Comments");
            DropTable("dbo.Papers");
            DropTable("dbo.Catagories");
        }
    }
}
