namespace PetroTech.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _14032019 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.IdentityUsers", "UserCode", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            DropColumn("dbo.IdentityUsers", "UserCode");
        }
    }
}
