namespace LeadsWithAuth.Models
{
    using System.ComponentModel.DataAnnotations;

    public class InspectionType
    {
        public int Id { get; set; }
        [Required]
        public string Code { get; set; }
        public string Desscription { get; set; }
    }
}