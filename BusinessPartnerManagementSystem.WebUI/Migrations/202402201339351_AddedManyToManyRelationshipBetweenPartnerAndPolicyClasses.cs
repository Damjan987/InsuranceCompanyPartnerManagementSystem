namespace BusinessPartnerManagementSystem.WebUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedManyToManyRelationshipBetweenPartnerAndPolicyClasses : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PolicyPartners",
                c => new
                    {
                        Policy_Id = c.String(nullable: false, maxLength: 128),
                        Partner_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Policy_Id, t.Partner_Id })
                .ForeignKey("dbo.Policies", t => t.Policy_Id, cascadeDelete: true)
                .ForeignKey("dbo.Partners", t => t.Partner_Id, cascadeDelete: true)
                .Index(t => t.Policy_Id)
                .Index(t => t.Partner_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PolicyPartners", "Partner_Id", "dbo.Partners");
            DropForeignKey("dbo.PolicyPartners", "Policy_Id", "dbo.Policies");
            DropIndex("dbo.PolicyPartners", new[] { "Partner_Id" });
            DropIndex("dbo.PolicyPartners", new[] { "Policy_Id" });
            DropTable("dbo.PolicyPartners");
        }
    }
}
