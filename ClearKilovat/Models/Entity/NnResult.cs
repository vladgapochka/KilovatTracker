using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ClearKilovat.Models.Entity
{
    /// <summary>
    /// Результат работы нейронной сети по тому же объекту Account.
    /// Схема «one-to-one» через общий PK/FK <see cref="AccountId"/>.
    /// </summary>
    [Table("nn_results")]
    public class NnResult
    {
        /// <summary>
        /// PK и FK на <c>accounts.account_id</c>.
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
        /// Дата-время, когда модель сделала предсказание.
        /// Используется для отслеживания «свежести» результатов.
        /// </summary>
        [Column("predicted_at")]
        public DateTime PredictedAt { get; set; }

        /// <summary>
        /// Навигационное свойство к основной записи Account.
        /// </summary>
        public Account Account { get; set; }
    }
}
