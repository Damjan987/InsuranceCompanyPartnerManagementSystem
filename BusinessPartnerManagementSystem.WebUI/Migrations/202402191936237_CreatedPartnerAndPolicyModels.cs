namespace BusinessPartnerManagementSystem.WebUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedPartnerAndPolicyModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Partners",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(nullable: false, maxLength: 255),
                        LastName = c.String(nullable: false, maxLength: 255),
                        Address = c.String(),
                        PartnerNumber = c.Int(nullable: false),
                        CroatianPIN = c.String(),
                        PartnerTypeId = c.Int(nullable: false),
                        CreatedAtUtc = c.DateTime(nullable: false),
                        CreateByUser = c.String(nullable: false, maxLength: 20),
                        IsForeign = c.Boolean(nullable: false),
                        ExternalCode = c.String(maxLength: 20),
                        Gender = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Policies",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        PolicyNumber = c.String(nullable: false, maxLength: 15),
                        PolicyPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Policies");
            DropTable("dbo.Partners");
        }
    }
}
