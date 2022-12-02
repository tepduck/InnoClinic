using System.ComponentModel.DataAnnotations.Schema;

namespace Authorization.Domain.Models
{
    public class ServiceCategory
    {
        [Column("ServiceCategoryId")]
        public Guid Id { get; set; }
        public string CategoryName { get; set; }
        public string TimeSlotSize { get; set; }

        [ForeignKey(nameof(Service))]
        public Guid ServiceId { get; set; }
        public Service Service { get; set; }
    }
}
