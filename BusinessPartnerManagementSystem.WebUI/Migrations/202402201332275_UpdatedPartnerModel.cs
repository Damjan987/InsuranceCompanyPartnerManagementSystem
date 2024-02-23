namespace BusinessPartnerManagementSystem.WebUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedPartnerModel : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Partners", "ExternalCode", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Partners", new[] { "ExternalCode" });
        }
    }
}
