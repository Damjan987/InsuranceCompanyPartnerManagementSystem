namespace BusinessPartnerManagementSystem.WebUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCreatedAtFieldToBaseEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Partners", "CreatedAt", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Policies", "CreatedAt", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Policies", "CreatedAt");
            DropColumn("dbo.Partners", "CreatedAt");
        }
    }
}
