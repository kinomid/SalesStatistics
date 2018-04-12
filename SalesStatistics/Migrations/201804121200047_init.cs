namespace SalesStatistics.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SalesStatistics",
                c => new
                    {
                        Type1_ClassifierId = c.String(nullable: false, maxLength: 50),
                        Type2_ClassifierId = c.String(nullable: false, maxLength: 50),
                        Type3_ClassifierId = c.String(nullable: false, maxLength: 50),
                        Type4_ClassifierId = c.String(nullable: false, maxLength: 50),
                        ShipDate = c.DateTime(nullable: false, storeType: "date"),
                        Amount = c.Decimal(nullable: false, precision: 28, scale: 12, storeType: "numeric"),
                    })
                .PrimaryKey(t => new { t.Type1_ClassifierId, t.Type2_ClassifierId, t.Type3_ClassifierId, t.Type4_ClassifierId, t.ShipDate })
                .ForeignKey("dbo.Type1_Classifier", t => t.Type1_ClassifierId, cascadeDelete: true)
                .ForeignKey("dbo.Type2_Classifier", t => t.Type2_ClassifierId, cascadeDelete: true)
                .ForeignKey("dbo.Type3_Classifier", t => t.Type3_ClassifierId, cascadeDelete: true)
                .ForeignKey("dbo.Type4_Classifier", t => t.Type4_ClassifierId, cascadeDelete: true)
                .Index(t => t.Type1_ClassifierId)
                .Index(t => t.Type2_ClassifierId)
                .Index(t => t.Type3_ClassifierId)
                .Index(t => t.Type4_ClassifierId);
            
            CreateTable(
                "dbo.Type1_Classifier",
                c => new
                    {
                        ClassifierId = c.String(nullable: false, maxLength: 50),
                        ClassifierName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ClassifierId);
            
            CreateTable(
                "dbo.Type2_Classifier",
                c => new
                    {
                        ClassifierId = c.String(nullable: false, maxLength: 50),
                        ClassifierName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ClassifierId);
            
            CreateTable(
                "dbo.Type3_Classifier",
                c => new
                    {
                        ClassifierId = c.String(nullable: false, maxLength: 50),
                        ClassifierName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ClassifierId);
            
            CreateTable(
                "dbo.Type4_Classifier",
                c => new
                    {
                        ClassifierId = c.String(nullable: false, maxLength: 50),
                        ClassifierName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ClassifierId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SalesStatistics", "Type4_ClassifierId", "dbo.Type4_Classifier");
            DropForeignKey("dbo.SalesStatistics", "Type3_ClassifierId", "dbo.Type3_Classifier");
            DropForeignKey("dbo.SalesStatistics", "Type2_ClassifierId", "dbo.Type2_Classifier");
            DropForeignKey("dbo.SalesStatistics", "Type1_ClassifierId", "dbo.Type1_Classifier");
            DropIndex("dbo.SalesStatistics", new[] { "Type4_ClassifierId" });
            DropIndex("dbo.SalesStatistics", new[] { "Type3_ClassifierId" });
            DropIndex("dbo.SalesStatistics", new[] { "Type2_ClassifierId" });
            DropIndex("dbo.SalesStatistics", new[] { "Type1_ClassifierId" });
            DropTable("dbo.Type4_Classifier");
            DropTable("dbo.Type3_Classifier");
            DropTable("dbo.Type2_Classifier");
            DropTable("dbo.Type1_Classifier");
            DropTable("dbo.SalesStatistics");
        }
    }
}
