using Common.Enumeraties;

namespace Models
{
    public class EntityParamDto
    {
        public OperatorEnum ParamOperator { get; set; } = OperatorEnum.Equal;

        /// <summary>
        /// FieldName
        /// </summary>
        public string? FieldName { get; set; }

        /// <summary>
        /// FieldValue
        /// </summary>
        public string? FieldValue { get; set; }
    }
}
