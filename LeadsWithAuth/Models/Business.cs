namespace LeadsWithAuth.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Business
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}