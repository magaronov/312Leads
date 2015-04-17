namespace LeadsWithAuth.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class FacilityType
    {
        public int FacilityTypeId { get; set; }

        [Required]
        public string Code { get; set; }

        public string Desscription { get; set; }

        public virtual ICollection<Facility> Facilities { get; set; }
    }
}