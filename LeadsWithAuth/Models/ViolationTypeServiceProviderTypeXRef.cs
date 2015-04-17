namespace LeadsWithAuth.Models
{
    public class ViolationTypeServiceProviderTypeXRef
    {
        public int Id { get; set; }
        public int ViolationTypeId { get; set; }
        public int ServiceProviderTypeId { get; set; }

        public virtual ViolationType ViolationType { get; set; }
        public virtual ServiceProviderType ServiceProviderType { get; set; }
    }
}