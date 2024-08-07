namespace ModelLibrary.Model
{
    public class NetworkRuleDto
    {
        /// <summary>
        /// Идентификатор в наших системах.
        /// </summary>
        public int NetworkRuleID { get; set; }

        /// <summary>
        /// Сеть, к которой применяется данное правило.
        /// </summary>
        public int NetworkID { get; set; }

        /// <summary>
        /// Пользователь, к которому применяется данное правило. Если не указан, то применяется ко всем пользователям сети, кроме гостей.
        /// </summary>
        public int? UserID { get; set; }

        /// <summary>
        /// Тип уведомления, который необходимо отправить, в случае выполнения условия.
        /// </summary>
        public string? NotificationType { get; set; }

        /// <summary>
        /// Условие в строковом формате.
        /// </summary>
        public string? RuleExpression { get; set; }

        /// <summary>
        /// Условие в структурированном формате.
        /// </summary>
        public RuleItemDto? Rule { get;set; }
    }
}