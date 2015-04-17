namespace LeadsWithAuth.Models
{
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class RiskLevel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public int RiskLevelId { get; set; }

        [Required]
        public string Code { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Facility> Facilities { get; set; }
    }
}