namespace LeadsWithAuth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialSeed : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FacilityTypes", "Description", c => c.String());
            AddColumn("dbo.InspectionTypes", "Description", c => c.String());
            AddColumn("dbo.ServiceProviderTypes", "Description", c => c.String());
            AddColumn("dbo.ViolationTypes", "Description", c => c.String());
            DropColumn("dbo.FacilityTypes", "Desscription");
            DropColumn("dbo.InspectionTypes", "Desscription");
            DropColumn("dbo.ServiceProviderTypes", "Desscription");
            DropColumn("dbo.ViolationTypes", "Desscription");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ViolationTypes", "Desscription", c => c.String());
            AddColumn("dbo.ServiceProviderTypes", "Desscription", c => c.String());
            AddColumn("dbo.InspectionTypes", "Desscription", c => c.String());
            AddColumn("dbo.FacilityTypes", "Desscription", c => c.String());
            DropColumn("dbo.ViolationTypes", "Description");
            DropColumn("dbo.ServiceProviderTypes", "Description");
            DropColumn("dbo.InspectionTypes", "Description");
            DropColumn("dbo.FacilityTypes", "Description");
        }
    }
}
