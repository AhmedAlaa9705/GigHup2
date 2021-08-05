namespace GigHup2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addattensance : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendances",
                c => new
                    {
                        GigId = c.Int(nullable: false),
                        UserAttendId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.GigId, t.UserAttendId })
                .ForeignKey("dbo.Gigs", t => t.GigId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserAttendId, cascadeDelete: true)
                .Index(t => t.GigId)
                .Index(t => t.UserAttendId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Attendances", "UserAttendId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Attendances", "GigId", "dbo.Gigs");
            DropIndex("dbo.Attendances", new[] { "UserAttendId" });
            DropIndex("dbo.Attendances", new[] { "GigId" });
            DropTable("dbo.Attendances");
        }
    }
}
