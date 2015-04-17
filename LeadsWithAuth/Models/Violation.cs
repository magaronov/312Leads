namespace LeadsWithAuth.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Violation
    {
        [Key]
        [Column(Order = 1)] 
        public int InspectionId { get; set; }

        [Key]
        [Column(Order = 2)] 
        public int ViolationTypeId { get; set; }

        public string Comment { get; set; }

        public virtual Inspection Inspection { get; set; }
        public virtual ViolationType ViolationType { get; set; }
    }
}