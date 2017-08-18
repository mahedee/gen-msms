namespace MSMS.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migr1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "AdmissionReferanceId", c => c.Int(nullable: false));
            DropColumn("dbo.Students", "AdmissionReferance");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "AdmissionReferance", c => c.Int(nullable: false));
            DropColumn("dbo.Students", "AdmissionReferanceId");
        }
    }
}
