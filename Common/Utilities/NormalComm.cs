namespace Common.Utilities
{
    public static class NormalComm
    {
        /// <summary>
        /// 填充树状数据子对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parent"></param>
        /// <param name="data"></param>
        /// <param name="pPropName"></param>
        /// <param name="cPropName"></param>
        /// <param name="childPropName"></param>
        /// <param name="setMethodName"></param>
        public static void FillChildren<T>(this T parent, List<T> data, string pPropName = "id", string cPropName = "parentId", string childPropName = "children", string setMethodName = "SetChildren") where T : class
        {
            var t = typeof(T);
            var pPropValue = t.GetProperty(pPropName)?.GetValue(parent);
            if (pPropValue != null)
            {
                var children = new List<T>();
                data.ForEach(item => 
                { 
                    if(pPropValue.Equals(t.GetProperty(cPropName)?.GetValue(item)))
                    {
                        children.Add(item);
                        item.FillChildren(data, pPropName, cPropName, childPropName);
                    }
                });
                t.GetMethod(setMethodName)?.Invoke(parent, new object[] { children });
            }
        }

        /// <summary>
        /// 字节数组转Base64
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string BufferToBase64String(this byte[]? bytes)
        {
            if (bytes?.Length > 0)
            {
                return Convert.ToBase64String(bytes, 0, bytes.Length);
            }

            return string.Empty;
        }

        /// <summary>
        /// 默认查询条件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static (int, int, int, string, string) GetDefaultCondition<T>(this T entity) => (0, (int)(typeof(T).GetProperty("pageIndex")?.GetValue(entity) ?? "1"), (int)(typeof(T).GetProperty("pageSize")?.GetValue(entity) ?? "10"), (string)(typeof(T).GetProperty("sortBy")?.GetValue(entity) ?? "creationTime"), (string)(typeof(T).GetProperty("direction")?.GetValue(entity) ?? "DESC"));

        /// <summary>
        /// 截取长度
        /// </summary>
        /// <param name="str"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string CutLength(this string str, int length = 2000) => str.Substring(0, length);
    }
}
