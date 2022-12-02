using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Authorization.Domain.Models
{
    public class Patient
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public bool isAccountLinked { get; set; }
        public DateTime DateOfBirth { get; set; }

        public Guid AccountId { get; set; }
        public Account Account { get; set; }

       // public ICollection<Appoitment> Appoitments { get; set; }
    }
}
