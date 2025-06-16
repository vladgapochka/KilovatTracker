using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ClearKilovat.Models.Entity
{
    [Table("accounts")]
    public class Account
    {
        [Key]
        [Column("account_id")]
        public int Id { get; set; }

        [Column("is_commercial")]
        public bool IsCommercial { get; set; }

        [Required]
        [Column("address")]
        public string Address { get; set; }

        [Column("building_type")]
        public string BuildingType { get; set; }

        [Column("rooms_count")]
        public int? RoomsCount { get; set; }

        [Column("residents_count")]
        public int? ResidentsCount { get; set; }

        [Column("total_area")]
        public decimal? TotalArea { get; set; }

        public List<Consumption> Consumptions { get; set; }
        public ParserAnalytics? ParserAnalytics { get; set; }
        public NnResult? NnResult { get; set; }
        public List<SmartMeterReading>? SmartMeterReading { get; set; }


    }
}
