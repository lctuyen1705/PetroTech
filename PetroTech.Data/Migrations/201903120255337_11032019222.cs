namespace PetroTech.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _11032019222 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Areas");
            DropTable("dbo.Departments");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentId = c.String(nullable: false, maxLength: 128),
                        DepartmentName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Areas",
                c => new
                    {
                        AreaId = c.String(nullable: false, maxLength: 128),
                        AreaName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.AreaId);
            
        }
    }
}
