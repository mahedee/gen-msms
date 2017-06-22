namespace MSMS.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class subject : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClassId = c.Int(nullable: false),
                        SubjectCode = c.String(),
                        SubjectName = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ClassInfoes", t => t.ClassId, cascadeDelete: true)
                .Index(t => t.ClassId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Subjects", "ClassId", "dbo.ClassInfoes");
            DropIndex("dbo.Subjects", new[] { "ClassId" });
            DropTable("dbo.Subjects");
        }
    }
}
