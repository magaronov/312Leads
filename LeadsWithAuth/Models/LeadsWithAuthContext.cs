using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LeadsWithAuth.Models
{
    public class LeadsWithAuthContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public LeadsWithAuthContext() : base("name=LeadsWithAuthContext")
        {
        }

        public DbSet<RiskLevel> RiskLevels { get; set; }
        public DbSet<FacilityType> FacilityTypes { get; set; }
        public DbSet<InspectionType> InspectionTypes { get; set; }
        public DbSet<ViolationType> ViolationTypes { get; set; }
        public DbSet<ServiceProviderType> ServiceProviderTypes { get; set; }
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<Inspection> Inspections { get; set; }
        public DbSet<Violation> Violations { get; set; }
        public DbSet<ViolationTypeServiceProviderTypeXRef> ViolationTypeServiceProviderTypeXRefs { get; set; }
    }
}
