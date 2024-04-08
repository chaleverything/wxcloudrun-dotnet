using Common.Enumeraties;

namespace Models
{
    public class EntityParamsDto
    {
        /// <summary>
        /// ParamOperator
        /// </summary>
        public OperatorEnum ParamOperator { get; set; } = OperatorEnum.Or;

        /// <summary>
        /// LstEntityParam
        /// </summary>
        public List<EntityParamDto> LstEntityParam { get; set; } = new List<EntityParamDto>();
    }
}
