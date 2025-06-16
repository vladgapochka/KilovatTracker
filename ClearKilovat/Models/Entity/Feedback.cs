using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClearKilovat.Models.Entity
{
    
    [Table("feedbacks")]
    public class Feedback
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("account_id")]
        public int? AccountId { get; set; }
        [Column("is_anonym")]
        public bool IsAnonym { get; set; } = false;
        [Column("is_readed")]
        public bool IsReaded { get; set; } = false;
        [Column("message")]
        public string Message { get; set; } =string.Empty;
        [Column("created_date")]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
