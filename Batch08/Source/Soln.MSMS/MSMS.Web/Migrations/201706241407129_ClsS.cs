namespace MSMS.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClsS : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ClassSchedules", "RoomId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ClassSchedules", "RoomId");
        }
    }
}
