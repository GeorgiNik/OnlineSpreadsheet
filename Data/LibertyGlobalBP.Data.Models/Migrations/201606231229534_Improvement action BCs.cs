namespace RecommendIT.Data.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImprovementactionBCs : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.QuestionnaireTouchpointTypes", newName: "TouchpointTypeQuestionnaires");
            DropForeignKey("dbo.ImprovementActionBusinessLines", "ImprovementAction_ID", "dbo.ImprovementActions");
            DropForeignKey("dbo.ImprovementActionBusinessLines", "BusinessLine_ID", "dbo.BusinessLines");
            DropForeignKey("dbo.ImprovementActionCountries", "ImprovementAction_ID", "dbo.ImprovementActions");
            DropForeignKey("dbo.ImprovementActionCountries", "Country_ID", "dbo.Countries");
            DropForeignKey("dbo.CustomerImprovementActions", "Customer_ID", "dbo.Customers");
            DropForeignKey("dbo.CustomerImprovementActions", "ImprovementAction_ID", "dbo.ImprovementActions");
            DropForeignKey("dbo.TouchpointTypeImprovementActions", "TouchpointType_ID", "dbo.TouchpointTypes");
            DropForeignKey("dbo.TouchpointTypeImprovementActions", "ImprovementAction_ID", "dbo.ImprovementActions");
            DropIndex("dbo.ImprovementActionBusinessLines", new[] { "ImprovementAction_ID" });
            DropIndex("dbo.ImprovementActionBusinessLines", new[] { "BusinessLine_ID" });
            DropIndex("dbo.ImprovementActionCountries", new[] { "ImprovementAction_ID" });
            DropIndex("dbo.ImprovementActionCountries", new[] { "Country_ID" });
            DropIndex("dbo.CustomerImprovementActions", new[] { "Customer_ID" });
            DropIndex("dbo.CustomerImprovementActions", new[] { "ImprovementAction_ID" });
            DropIndex("dbo.TouchpointTypeImprovementActions", new[] { "TouchpointType_ID" });
            DropIndex("dbo.TouchpointTypeImprovementActions", new[] { "ImprovementAction_ID" });
            DropPrimaryKey("dbo.TouchpointTypeQuestionnaires");
            CreateTable(
                "dbo.ImprovementActionBcs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ImprovementActionID = c.Int(nullable: false),
                        BusinessLineID = c.Int(),
                        CountryID = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.BusinessLines", t => t.BusinessLineID)
                .ForeignKey("dbo.Countries", t => t.CountryID)
                .ForeignKey("dbo.ImprovementActions", t => t.ImprovementActionID, cascadeDelete: true)
                .Index(t => t.ImprovementActionID)
                .Index(t => t.BusinessLineID)
                .Index(t => t.CountryID);
            
            CreateTable(
                "dbo.CustomerImprovementActionBcs",
                c => new
                    {
                        Customer_ID = c.Int(nullable: false),
                        ImprovementActionBcs_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Customer_ID, t.ImprovementActionBcs_ID })
                .ForeignKey("dbo.Customers", t => t.Customer_ID, cascadeDelete: true)
                .ForeignKey("dbo.ImprovementActionBcs", t => t.ImprovementActionBcs_ID, cascadeDelete: true)
                .Index(t => t.Customer_ID)
                .Index(t => t.ImprovementActionBcs_ID);
            
            CreateTable(
                "dbo.ImprovementActionBcsTouchpointTypes",
                c => new
                    {
                        ImprovementActionBcs_ID = c.Int(nullable: false),
                        TouchpointType_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ImprovementActionBcs_ID, t.TouchpointType_ID })
                .ForeignKey("dbo.ImprovementActionBcs", t => t.ImprovementActionBcs_ID, cascadeDelete: true)
                .ForeignKey("dbo.TouchpointTypes", t => t.TouchpointType_ID, cascadeDelete: true)
                .Index(t => t.ImprovementActionBcs_ID)
                .Index(t => t.TouchpointType_ID);
            
            AddPrimaryKey("dbo.TouchpointTypeQuestionnaires", new[] { "TouchpointType_ID", "Questionnaire_ID" });
            DropTable("dbo.ImprovementActionBusinessLines");
            DropTable("dbo.ImprovementActionCountries");
            DropTable("dbo.CustomerImprovementActions");
            DropTable("dbo.TouchpointTypeImprovementActions");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TouchpointTypeImprovementActions",
                c => new
                    {
                        TouchpointType_ID = c.Int(nullable: false),
                        ImprovementAction_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TouchpointType_ID, t.ImprovementAction_ID });
            
            CreateTable(
                "dbo.CustomerImprovementActions",
                c => new
                    {
                        Customer_ID = c.Int(nullable: false),
                        ImprovementAction_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Customer_ID, t.ImprovementAction_ID });
            
            CreateTable(
                "dbo.ImprovementActionCountries",
                c => new
                    {
                        ImprovementAction_ID = c.Int(nullable: false),
                        Country_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ImprovementAction_ID, t.Country_ID });
            
            CreateTable(
                "dbo.ImprovementActionBusinessLines",
                c => new
                    {
                        ImprovementAction_ID = c.Int(nullable: false),
                        BusinessLine_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ImprovementAction_ID, t.BusinessLine_ID });
            
            DropForeignKey("dbo.ImprovementActionBcsTouchpointTypes", "TouchpointType_ID", "dbo.TouchpointTypes");
            DropForeignKey("dbo.ImprovementActionBcsTouchpointTypes", "ImprovementActionBcs_ID", "dbo.ImprovementActionBcs");
            DropForeignKey("dbo.ImprovementActionBcs", "ImprovementActionID", "dbo.ImprovementActions");
            DropForeignKey("dbo.CustomerImprovementActionBcs", "ImprovementActionBcs_ID", "dbo.ImprovementActionBcs");
            DropForeignKey("dbo.CustomerImprovementActionBcs", "Customer_ID", "dbo.Customers");
            DropForeignKey("dbo.ImprovementActionBcs", "CountryID", "dbo.Countries");
            DropForeignKey("dbo.ImprovementActionBcs", "BusinessLineID", "dbo.BusinessLines");
            DropIndex("dbo.ImprovementActionBcsTouchpointTypes", new[] { "TouchpointType_ID" });
            DropIndex("dbo.ImprovementActionBcsTouchpointTypes", new[] { "ImprovementActionBcs_ID" });
            DropIndex("dbo.CustomerImprovementActionBcs", new[] { "ImprovementActionBcs_ID" });
            DropIndex("dbo.CustomerImprovementActionBcs", new[] { "Customer_ID" });
            DropIndex("dbo.ImprovementActionBcs", new[] { "CountryID" });
            DropIndex("dbo.ImprovementActionBcs", new[] { "BusinessLineID" });
            DropIndex("dbo.ImprovementActionBcs", new[] { "ImprovementActionID" });
            DropPrimaryKey("dbo.TouchpointTypeQuestionnaires");
            DropTable("dbo.ImprovementActionBcsTouchpointTypes");
            DropTable("dbo.CustomerImprovementActionBcs");
            DropTable("dbo.ImprovementActionBcs");
            AddPrimaryKey("dbo.TouchpointTypeQuestionnaires", new[] { "Questionnaire_ID", "TouchpointType_ID" });
            CreateIndex("dbo.TouchpointTypeImprovementActions", "ImprovementAction_ID");
            CreateIndex("dbo.TouchpointTypeImprovementActions", "TouchpointType_ID");
            CreateIndex("dbo.CustomerImprovementActions", "ImprovementAction_ID");
            CreateIndex("dbo.CustomerImprovementActions", "Customer_ID");
            CreateIndex("dbo.ImprovementActionCountries", "Country_ID");
            CreateIndex("dbo.ImprovementActionCountries", "ImprovementAction_ID");
            CreateIndex("dbo.ImprovementActionBusinessLines", "BusinessLine_ID");
            CreateIndex("dbo.ImprovementActionBusinessLines", "ImprovementAction_ID");
            AddForeignKey("dbo.TouchpointTypeImprovementActions", "ImprovementAction_ID", "dbo.ImprovementActions", "ID", cascadeDelete: true);
            AddForeignKey("dbo.TouchpointTypeImprovementActions", "TouchpointType_ID", "dbo.TouchpointTypes", "ID", cascadeDelete: true);
            AddForeignKey("dbo.CustomerImprovementActions", "ImprovementAction_ID", "dbo.ImprovementActions", "ID", cascadeDelete: true);
            AddForeignKey("dbo.CustomerImprovementActions", "Customer_ID", "dbo.Customers", "ID", cascadeDelete: true);
            AddForeignKey("dbo.ImprovementActionCountries", "Country_ID", "dbo.Countries", "ID", cascadeDelete: true);
            AddForeignKey("dbo.ImprovementActionCountries", "ImprovementAction_ID", "dbo.ImprovementActions", "ID", cascadeDelete: true);
            AddForeignKey("dbo.ImprovementActionBusinessLines", "BusinessLine_ID", "dbo.BusinessLines", "ID", cascadeDelete: true);
            AddForeignKey("dbo.ImprovementActionBusinessLines", "ImprovementAction_ID", "dbo.ImprovementActions", "ID", cascadeDelete: true);
            RenameTable(name: "dbo.TouchpointTypeQuestionnaires", newName: "QuestionnaireTouchpointTypes");
        }
    }
}
