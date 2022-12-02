using System.ComponentModel.DataAnnotations.Schema;

namespace Authorization.Domain.Models
{
    public class Service
    {
        [Column("ServiceId")]
        public Guid Id { get; set; }
        public string CategoryName { get; set; }
        public string Price { get; set; }
        public bool IsActive { get; set; }

        public Guid AppoitmentId { get; set; }
        public Appoitment Appoitment { get; set; }

        public ICollection<ServiceCategory> ServiceCategories { get; set; }
        public ICollection<Specialization> Specializations { get; set; }
    }
}
