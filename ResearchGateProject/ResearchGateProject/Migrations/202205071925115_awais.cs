namespace ResearchGateProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class awais : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Papers", "header", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Papers", "header");
        }
    }
}
