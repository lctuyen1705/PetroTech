namespace PetroTech.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tuyenlc : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Functions",
                c => new
                    {
                        FunctionId = c.Guid(nullable: false),
                        FunctionType = c.String(nullable: false),
                        FunctionName = c.String(nullable: false),
                        Component = c.String(nullable: false),
                        ModuleCode = c.String(nullable: false),
                        ModuleName = c.String(nullable: false),
                        Controller = c.String(nullable: false),
                        Status = c.String(nullable: false),
                        CreateDateTime = c.DateTime(),
                        CreatedBy = c.String(maxLength: 250),
                        LastUpdatedDateTime = c.DateTime(),
                        LastUpdatedBy = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.FunctionId);
            
            CreateTable(
                "dbo.Logs",
                c => new
                    {
                        ErrorId = c.Guid(nullable: false),
                        MessageError = c.String(),
                        StackTrance = c.String(),
                        CreatedDateTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.ErrorId);
            
            CreateTable(
                "dbo.Permissions",
                c => new
                    {
                        FunctionId = c.Guid(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 128),
                        IsPermisstion = c.Boolean(nullable: false),
                        CreateDateTime = c.DateTime(),
                        CreatedBy = c.String(maxLength: 250),
                        LastUpdatedDateTime = c.DateTime(),
                        LastUpdatedBy = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => new { t.FunctionId, t.UserName })
                .ForeignKey("dbo.Functions", t => t.FunctionId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserName, cascadeDelete: true)
                .Index(t => t.FunctionId)
                .Index(t => t.UserName);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserName = c.String(nullable: false, maxLength: 128),
                        FullName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        DOB = c.DateTime(nullable: false),
                        Department = c.String(maxLength: 250),
                        Address = c.String(maxLength: 250),
                        City = c.String(maxLength: 250),
                        Area = c.String(maxLength: 250),
                        Status = c.String(nullable: false),
                        CreateDateTime = c.DateTime(),
                        CreatedBy = c.String(maxLength: 250),
                        LastUpdatedDateTime = c.DateTime(),
                        LastUpdatedBy = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.UserName);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleId = c.Guid(nullable: false),
                        RoleCode = c.String(nullable: false),
                        RoleName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        UserName = c.String(nullable: false, maxLength: 128),
                        RoleId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserName, t.RoleId })
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserName, cascadeDelete: true)
                .Index(t => t.UserName)
                .Index(t => t.RoleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRoles", "UserName", "dbo.Users");
            DropForeignKey("dbo.UserRoles", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Permissions", "UserName", "dbo.Users");
            DropForeignKey("dbo.Permissions", "FunctionId", "dbo.Functions");
            DropIndex("dbo.UserRoles", new[] { "RoleId" });
            DropIndex("dbo.UserRoles", new[] { "UserName" });
            DropIndex("dbo.Permissions", new[] { "UserName" });
            DropIndex("dbo.Permissions", new[] { "FunctionId" });
            DropTable("dbo.UserRoles");
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
            DropTable("dbo.Permissions");
            DropTable("dbo.Logs");
            DropTable("dbo.Functions");
        }
    }
}
