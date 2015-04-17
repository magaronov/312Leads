namespace LeadsWithAuth.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Inspection
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public int Id { get; set; }
        public bool Result { get; set; }
        public DateTime InspectionDateTime { get; set; }

        public int FacilityId { get; set; }
        public int InspectionTypeId { get; set; }

        public virtual Facility Facility { get; set; }
        public virtual InspectionType InspectionType { get; set; }
    }
}