using System.ComponentModel.DataAnnotations.Schema;

namespace Authorization.Domain.Models
{
    public class Document
    {
        [Column("DocumentId")]
        public Guid ID { get; set; }
        public string Url { get; set; }

        [ForeignKey(nameof(Result))]
        public Guid ResultId { get; set; }
        public Result Result { get; set; }

    }
}
