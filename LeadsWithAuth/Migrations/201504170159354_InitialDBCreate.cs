namespace LeadsWithAuth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDBCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Facilities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        AkaName = c.String(),
                        LicenseNumber = c.Int(nullable: false),
                        Address = c.String(),
                        City = c.String(),
                        StateCode = c.String(),
                        ZipCode = c.Int(nullable: false),
                        Latitude = c.Single(nullable: false),
                        Longitude = c.Single(nullable: false),
                        FacilityTypeId = c.Int(nullable: false),
                        RiskLevelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FacilityTypes", t => t.FacilityTypeId, cascadeDelete: true)
                .ForeignKey("dbo.RiskLevels", t => t.RiskLevelId, cascadeDelete: true)
                .Index(t => t.FacilityTypeId)
                .Index(t => t.RiskLevelId);
            
            CreateTable(
                "dbo.FacilityTypes",
                c => new
                    {
                        FacilityTypeId = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false),
                        Desscription = c.String(),
                    })
                .PrimaryKey(t => t.FacilityTypeId);
            
            CreateTable(
                "dbo.Inspections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Result = c.Boolean(nullable: false),
                        InspectionDateTime = c.DateTime(nullable: false),
                        FacilityId = c.Int(nullable: false),
                        InspectionTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Facilities", t => t.FacilityId, cascadeDelete: true)
                .ForeignKey("dbo.InspectionTypes", t => t.InspectionTypeId, cascadeDelete: true)
                .Index(t => t.FacilityId)
                .Index(t => t.InspectionTypeId);
            
            CreateTable(
                "dbo.RiskLevels",
                c => new
                    {
                        RiskLevelId = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.RiskLevelId);
            
            CreateTable(
                "dbo.ServiceProviderTypes",
                c => new
                    {
                        ViolationTypeId = c.Int(nullable: false, identity: true),
                        Desscription = c.String(),
                    })
                .PrimaryKey(t => t.ViolationTypeId);
            
            CreateTable(
                "dbo.Violations",
                c => new
                    {
                        InspectionId = c.Int(nullable: false),
                        ViolationTypeId = c.Int(nullable: false),
                        Comment = c.String(),
                    })
                .PrimaryKey(t => new { t.InspectionId, t.ViolationTypeId })
                .ForeignKey("dbo.Inspections", t => t.InspectionId, cascadeDelete: true)
                .ForeignKey("dbo.ViolationTypes", t => t.ViolationTypeId, cascadeDelete: true)
                .Index(t => t.InspectionId)
                .Index(t => t.ViolationTypeId);
            
            CreateTable(
                "dbo.ViolationTypes",
                c => new
                    {
                        ViolationTypeId = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false),
                        Desscription = c.String(),
                    })
                .PrimaryKey(t => t.ViolationTypeId);
            
            CreateTable(
                "dbo.ViolationTypeServiceProviderTypeXRefs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ViolationTypeId = c.Int(nullable: false),
                        ServiceProviderTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceProviderTypes", t => t.ViolationTypeId, cascadeDelete: true)
                .ForeignKey("dbo.ViolationTypes", t => t.ViolationTypeId, cascadeDelete: true)
                .Index(t => t.ViolationTypeId);
            
            DropPrimaryKey("dbo.InspectionTypes");
            DropColumn("dbo.InspectionTypes", "Id");
            AddColumn("dbo.InspectionTypes", "InspectionTypeId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.InspectionTypes", "InspectionTypeId");
            DropTable("dbo.Businesses");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Businesses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.InspectionTypes", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.ViolationTypeServiceProviderTypeXRefs", "ViolationTypeId", "dbo.ViolationTypes");
            DropForeignKey("dbo.ViolationTypeServiceProviderTypeXRefs", "ViolationTypeId", "dbo.ServiceProviderTypes");
            DropForeignKey("dbo.Violations", "ViolationTypeId", "dbo.ViolationTypes");
            DropForeignKey("dbo.Violations", "InspectionId", "dbo.Inspections");
            DropForeignKey("dbo.Facilities", "RiskLevelId", "dbo.RiskLevels");
            DropForeignKey("dbo.Inspections", "InspectionTypeId", "dbo.InspectionTypes");
            DropForeignKey("dbo.Inspections", "FacilityId", "dbo.Facilities");
            DropForeignKey("dbo.Facilities", "FacilityTypeId", "dbo.FacilityTypes");
            DropIndex("dbo.ViolationTypeServiceProviderTypeXRefs", new[] { "ViolationTypeId" });
            DropIndex("dbo.ViolationTypeServiceProviderTypeXRefs", new[] { "ViolationTypeId" });
            DropIndex("dbo.Violations", new[] { "ViolationTypeId" });
            DropIndex("dbo.Violations", new[] { "InspectionId" });
            DropIndex("dbo.Facilities", new[] { "RiskLevelId" });
            DropIndex("dbo.Inspections", new[] { "InspectionTypeId" });
            DropIndex("dbo.Inspections", new[] { "FacilityId" });
            DropIndex("dbo.Facilities", new[] { "FacilityTypeId" });
            DropPrimaryKey("dbo.InspectionTypes");
            AddPrimaryKey("dbo.InspectionTypes", "Id");
            DropColumn("dbo.InspectionTypes", "InspectionTypeId");
            DropTable("dbo.ViolationTypeServiceProviderTypeXRefs");
            DropTable("dbo.ViolationTypes");
            DropTable("dbo.Violations");
            DropTable("dbo.ServiceProviderTypes");
            DropTable("dbo.RiskLevels");
            DropTable("dbo.Inspections");
            DropTable("dbo.FacilityTypes");
            DropTable("dbo.Facilities");
        }
    }
}
