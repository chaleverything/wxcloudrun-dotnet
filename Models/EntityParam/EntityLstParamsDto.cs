using Common.Enumeraties;

namespace Models
{
    public class EntityLstParamsDto
    {
        /// <summary>
        /// ParamOperator
        /// </summary>
        public OperatorEnum ParamOperator { get; set; } = OperatorEnum.None;

        /// <summary>
        /// LstEntityParams
        /// </summary>
        public List<EntityParamsDto> LstEntityParams { get; set; } = new List<EntityParamsDto>();
    }
}
