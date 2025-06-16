using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClearKilovat.Models.Entity
{
    /// <summary>
    /// Описывает сам счётчик, привязанный к абоненту
    /// </summary>
    [Table("smarts")]
    public class SmartMeter
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [ForeignKey(nameof(Account))]
        [Column("account_id")]
        public int AccountId { get; set; }
        public Account Account { get; set; }

        /// <summary>
        /// Серийный номер устройства или иной внешний идентификатор
        /// </summary>
        [Column("serial_number")]
        [MaxLength(50)]
        public string SerialNumber { get; set; }

        /// <summary>
        /// Все почасовые показания этого счетчика
        /// </summary>
        public List<SmartMeterReading> Readings { get; set; } = new();
    }

}
