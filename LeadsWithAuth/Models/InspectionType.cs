namespace LeadsWithAuth.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class InspectionType
    {
        public int InspectionTypeId { get; set; }

        [Required]
        public string Code { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Inspection> Inspections { get; set; }
    }
}