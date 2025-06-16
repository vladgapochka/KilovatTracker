using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ClearKilovat.Models.Entity
{
    /// <summary>
    /// Результат «плоского» парсера (Я-карты, 2ГИС и т. д.) для конкретного Account.
    /// Связь — один-к-одному через общий PK/FK <see cref="AccountId"/>.
    /// </summary>
    [Table("parser_analytics")]
    public class ParserAnalytics
    {
        /// <summary>
        /// PK и одновременно FK на <c>accounts.account_id</c>.
        /// Гарантирует, что для каждой записи в <c>accounts</c> может быть максимум
        /// один связанный результат парсера.
        /// </summary>
        [Key]
        [Column("account_id")]
        public int AccountId { get; set; }

        /// <summary>
        /// Человеко-читаемое предположение, полученное из парсинга
        /// внешних карт (пример: «Магазин», «Гостиница», «Частный дом»).
        /// </summary>
        [Column("description_reason")]
        public string? DescriptionReason { get; set; }

        /// <summary>
        /// Является нарушителем
        /// </summary>
        [Column("is_violator")]
        public bool IsViolator { get; set; }

        /// <summary>
        /// Дата-время, когда был выполнен парсинг.
        /// </summary>
        [Column("parsed_at")]
        public DateTime ParsedAt { get; set; }

        /// <summary>
        /// Навигационное свойство к основной записи Account.
        /// </summary>
        public Account Account { get; set; }
    }
}
