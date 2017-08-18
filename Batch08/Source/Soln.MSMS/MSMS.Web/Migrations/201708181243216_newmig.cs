namespace MSMS.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newmig : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "CellNumber", c => c.String());
            DropColumn("dbo.Employees", "Number");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "Number", c => c.String());
            DropColumn("dbo.Employees", "CellNumber");
        }
    }
}
