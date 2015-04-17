namespace LeadsWithAuth.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ServiceProviderType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key, Required]
        public int ViolationTypeId { get; set; }

        public string Desscription { get; set; }
    }
}