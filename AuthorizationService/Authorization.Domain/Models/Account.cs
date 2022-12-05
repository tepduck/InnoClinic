using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Authorization.Domain.Models
{
    public class Account : IdentityUser
    { 
        public string Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsEmailVerified { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedAt { get; set;}

        //public Guid PhotoId { get; set; }
        //public Photo Photo { get; set; }

        public string PatientId { get; set; }
        public Patient? Patient { get; set; }

        public string DoctorId { get; set; }
        public Doctor? Doctor { get; set; }

        public string ReceptionistId { get; set; }
        public Receptionist? Receptionist { get; set; }

    }
}
