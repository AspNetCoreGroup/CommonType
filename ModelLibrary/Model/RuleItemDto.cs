namespace ModelLibrary.Model
{
    public class RuleItemDto
    {
        public required RuleOperatorType Operator { get; set; }

        public string? OperatorParam { get; set; }

        public RuleItemDto? Operand1 { get; set; }

        public RuleItemDto? Operand2 { get; set; }
    }
}