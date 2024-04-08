using Common.Attributes;
using Common.Enumeraties;
using Models;

namespace EntityService
{
    public class Base
    {
        public List<T> Query<T, TT>(string filters) where T : class where TT : new()
        {
            var result = typeof(TT).GetMethod("Query")?.MakeGenericMethod(typeof(T)).Invoke(new TT(), new object[] { filters });
            return result == null ? new List<T>() : (List<T>)result;
        }

        public T? Find<T, TT>(string filters) where T : class where TT : new()
        {
            var result = typeof(TT).GetMethod("Find")?.MakeGenericMethod(typeof(T)).Invoke(new TT(), new object[] { filters });
            return result == null ? null : (T)result;
        }

        public bool Update<T, TT>(string filters, Dictionary<string, object> updateExpression) where T : class where TT : new()
        {
            var result = typeof(TT).GetMethod("Update")?.MakeGenericMethod(typeof(T)).Invoke(new TT(), new object[] { filters, updateExpression });
            return result == null ? false : (bool)result;
            //return new RDDataBase().Update<T>(filters, updateExpression);
        }

        public bool Remove<T, TT>(string filters) where T : class where TT : new()
        {
            var result = typeof(TT).GetMethod("Remove")?.MakeGenericMethod(typeof(T)).Invoke(new TT(), new object[] { filters });
            return result == null ? false : (bool)result;
        }


        public List<T> Query<T, TT>(EntityLstParamsDto lstParamsDto) where T : class where TT : new()
        {
            var result = typeof(TT).GetMethod("Query")?.MakeGenericMethod(typeof(T)).Invoke(new TT(), new object[] { FillParam(lstParamsDto) });
            return result == null ? new List<T>() : (List<T>)result;
            //return new RDDataBase().Query<T>(FillParam(lstParamsDto));
        }


        #region Fill

        /// <summary>
        /// FillParam
        /// </summary>
        /// <param name="lstParamsDto"></param>
        /// <returns></returns>
        public static string FillParam(EntityLstParamsDto lstParamsDto)
        {
            var result = string.Empty;

            if (lstParamsDto.ParamOperator == OperatorEnum.None)
            {
                result = FillEntityParams(lstParamsDto.LstEntityParams.FirstOrDefault());
            }
            else
            {
                var lstParamStr = new List<string>();

                foreach (var paramsDto in lstParamsDto.LstEntityParams)
                {
                    lstParamStr.Add("(" + FillEntityParams(paramsDto) + ")");
                }

                result = string.Join(lstParamsDto.ParamOperator.GetOperator(), lstParamStr);
            }

            return result;
        }

        /// <summary>
        /// FillEntityParams
        /// </summary>
        /// <param name="paramsDto"></param>
        /// <returns></returns>

        private static string FillEntityParams(EntityParamsDto? paramsDto)
        {
            if (paramsDto == null)
                return string.Empty;


            if (paramsDto.ParamOperator == OperatorEnum.None)
            {
                return FillEntityParam(paramsDto.LstEntityParam.FirstOrDefault());
            }

            var lstParamStr = new List<string>();
            foreach (var paramDto in paramsDto.LstEntityParam)
            {
                lstParamStr.Add(FillEntityParam(paramDto));
            }

            return string.Join(paramsDto.ParamOperator.GetOperator(), lstParamStr);
        }

        /// <summary>
        /// FillEntityParam
        /// </summary>
        /// <param name="paramDto"></param>
        /// <returns></returns>
        private static string FillEntityParam(EntityParamDto? paramDto)
        {
            if (paramDto == null)
                return string.Empty;

            return paramDto.FieldName + string.Format(paramDto.ParamOperator.GetOperator(), paramDto.FieldValue ?? string.Empty);
        }

        #endregion Fill
    }
}
