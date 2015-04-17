namespace LeadsWithAuth.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class Facility
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string AkaName { get; set; }

        [Required]
        public int LicenseNumber { get; set; }

        public string Address { get; set; }
        public string City { get; set; }
        public string StateCode { get; set; }
        public int ZipCode { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        //public DbGeography [GeoLocation] { get; set; }

        public int FacilityTypeId { get; set; }
        public int RiskLevelId { get; set; }

        public virtual RiskLevel RiskLevel { get; set; }
        public virtual FacilityType FacilityType { get; set; }
        public virtual ICollection<Inspection> Inspections { get; set; }
    }
}   