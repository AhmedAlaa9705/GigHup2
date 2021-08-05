namespace GigHup2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addiscancel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Gigs", "IsCancled", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Gigs", "IsCancled");
        }
    }
}
