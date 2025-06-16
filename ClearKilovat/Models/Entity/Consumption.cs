using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ClearKilovat.Models.Entity
{
    [Table("consumptions")]
    public class Consumption
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [ForeignKey("Account")]
        [Column("account_id")]
        public int AccountId { get; set; }

        public Account Account { get; set; }

        [Column("month")]
        public int Month { get; set; }

        [Column("value")]
        public int Value { get; set; }
    }
}
