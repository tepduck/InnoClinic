using System.ComponentModel.DataAnnotations.Schema;

namespace Authorization.Domain.Models
{
    public class Photo
    {
        public Guid Id { get; set; }
        public string Url { get; set; }

        public Guid AccountId { get; set; }
        public Account Account { get; set; }

        public Guid OfficeId { get; set; }
        public Office Office { get; set; }
    }
}
