namespace PetroTech.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tuyenlc2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Roles", "CreateDateTime", c => c.DateTime());
            AddColumn("dbo.Roles", "CreatedBy", c => c.String(maxLength: 250));
            AddColumn("dbo.Roles", "LastUpdatedDateTime", c => c.DateTime());
            AddColumn("dbo.Roles", "LastUpdatedBy", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Roles", "LastUpdatedBy");
            DropColumn("dbo.Roles", "LastUpdatedDateTime");
            DropColumn("dbo.Roles", "CreatedBy");
            DropColumn("dbo.Roles", "CreateDateTime");
        }
    }
}
