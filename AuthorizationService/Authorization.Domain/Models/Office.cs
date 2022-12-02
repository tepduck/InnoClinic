using System.ComponentModel.DataAnnotations.Schema;

namespace Authorization.Domain.Models
{
    public class Office
    {
        [Column("OfficeId")]
        public Guid Id { get; set; }
        public string Address { get; set; }
        public string RegistryPhoneNumber { get; set; }
        public bool IsActive { get; set; }

        [ForeignKey(nameof(Photo))]
        public Guid PhotoId { get; set; }
        public Photo Photo { get; set; }

        public Guid ReceptionistId { get; set; }
        public Receptionist Receptionist { get; set; }

        public ICollection<Doctor> Doctors { get; set; }
    }
}
