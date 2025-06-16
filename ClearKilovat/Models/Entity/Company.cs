using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClearKilovat.Models.Entity
{
    [Table("companies")]
    public class Company
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [ForeignKey("Account")]
        [Column("account_id")]
        public int AccountId { get; set; }

        [Column("name")]
        public string Name { get; set; } = string.Empty;

        [Column("adress")]
        public string Adress { get; set; } = string.Empty;
        [Column("phone_number")]
        public string? PhoneNumber { get; set; } = string.Empty;
    }
}
