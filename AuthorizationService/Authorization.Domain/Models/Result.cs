using System.ComponentModel.DataAnnotations.Schema;

namespace Authorization.Domain.Models
{
    public class Result
    {
        [Column("ResultId")]
        public Guid Id { get; set; }
        public string Complaints { get; set; }
        public string Conclusion { get; set; }
        public string Recomendations { get; set; }

        [ForeignKey(nameof(Appoitment))]
        public Guid AppoitmentId { get; set; }
        public Appoitment Appoitment { get; set; }

        public Guid DocumentId { get; set; }
        public Document Document { get; set; }
    }
}
