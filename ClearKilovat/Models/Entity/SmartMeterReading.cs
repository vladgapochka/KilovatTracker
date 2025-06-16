using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClearKilovat.Models.Entity
{
    /// <summary>
    /// Почасовое показание умного счётчика
    /// </summary>
    [Table("smart_readings")]
    public class SmartMeterReading
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [ForeignKey(nameof(SmartMeter))]
        [Column("smart_meter_id")]
        public int SmartMeterId { get; set; }
        public SmartMeter SmartMeter { get; set; }

        /// <summary>
        /// Момент снятия показания (UTC)
        /// </summary>
        [Column("timestamp")]
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Значение потребления за предыдущий час, кВт·ч
        /// </summary>
        [Column("consumption_kwh")]
        public decimal ConsumptionKwh { get; set; }
    }
}
