using System.ComponentModel.DataAnnotations.Schema;

namespace Authorization.Domain.Models
{
    public class Appoitment
    {
        [Column("AppoitmentId")]
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public bool isApproved { get; set; }

        [ForeignKey(nameof(Patient))]
        public Guid PatientId { get; set; }
        public Patient Patient { get; set; }

        [ForeignKey(nameof(Doctor))]
        public Guid DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        [ForeignKey(nameof(Service))]
        public Guid ServiceId { get; set; }
        public Service Service { get; set; }

        public Guid ResultId { get; set; }
        public Result Result { get; set; }
    }
}
