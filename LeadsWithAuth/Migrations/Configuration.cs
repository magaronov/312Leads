namespace LeadsWithAuth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using LeadsWithAuth.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<LeadsWithAuthContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(LeadsWithAuthContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            Models.InspectionType inspectionType1 = new Models.InspectionType { Code = "License", Description = "License" };
            Models.InspectionType inspectionType2 = new Models.InspectionType { Code = "Complaint", Description = "Complaint" };
            FacilityType facilityType = new FacilityType { Code = "Restaurant", Description = "Restaurant" };
            RiskLevel riskLevel = new RiskLevel { Code = "1", Description = "Risk 1 (High)" };


            context.InspectionTypes.AddOrUpdate(inspectionType1, inspectionType2);
            context.FacilityTypes.AddOrUpdate(facilityType);
            context.RiskLevels.AddOrUpdate(riskLevel);

            Facility facility = new Facility
            {
                Name = "Same Day Cafe",
                AkaName = "AKA - Same Day Cafe",
                Address = "5352 N Broadway St",
                City = "Chicago",
                StateCode = "IL",
                FacilityTypeId = facilityType.FacilityTypeId,
                ZipCode = 60614,
                RiskLevelId = riskLevel.RiskLevelId,
                LicenseNumber = 2350337
            };
            context.Facilities.AddOrUpdate(facility);

            Inspection inspection = new Inspection { FacilityId = facility.Id, InspectionDateTime = DateTime.Now, InspectionTypeId = 1, Result = false };
            context.Inspections.AddOrUpdate(inspection);
        }
    }
}
