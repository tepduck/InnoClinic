using System.ComponentModel.DataAnnotations.Schema;

namespace Authorization.Domain.Models
{
    public class Specialization
    {
        [Column("SpecializationId")]
        public Guid Id { get; set; }
        public string SpecializationName { get; set; }
        public bool IsActive { get; set; }

        [ForeignKey(nameof(Service))]
        public Guid ServiceId { get; set; }
        public Service Service { get; set; }

        [ForeignKey(nameof(Doctor))]
        public Guid DoctorId { get; set; }
        public Doctor Doctor { get; set; }
    }
}
