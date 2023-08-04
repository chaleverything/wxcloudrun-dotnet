namespace Common.Utilities
{
    public static class NormalComm
    {
        #region 填充树状数据子对象

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

        #endregion 填充树状数据子对象

        #region 字节数组转Base64

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

        #region 字节数组转Base64

        #endregion 默认查询条件

        /// <summary>
        /// 默认查询条件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static (int, int, int, string, string) GetDefaultCondition<T>(this T entity) => (0, (int)(typeof(T).GetProperty("pageIndex")?.GetValue(entity) ?? "1"), (int)(typeof(T).GetProperty("pageSize")?.GetValue(entity) ?? "10"), (string)(typeof(T).GetProperty("sortBy")?.GetValue(entity) ?? "creationTime"), (string)(typeof(T).GetProperty("direction")?.GetValue(entity) ?? "DESC"));

        #endregion 默认查询条件

        #region 截取长度

        /// <summary>
        /// 截取长度
        /// </summary>
        /// <param name="str"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string CutLength(this string str, int length = 2000) => str.Substring(0, length);

        #endregion 截取长度

        #region 获取环境变量值

        /// <summary>
        /// 获取环境变量值
        /// </summary>
        /// <returns></returns>
        public static string GetEnvironmentVariable()
        {
            return $"[U:{Environment.GetEnvironmentVariable("MYSQL_USERNAME")}][P:{Environment.GetEnvironmentVariable("MYSQL_PASSWORD")}][H:{Environment.GetEnvironmentVariable("MYSQL_ADDRESS")}]";
        }

        #endregion 获取环境变量值

        #region 将一个实体相同命名属性值赋值给另一个实体

        /// <summary>
        /// 将一个实体相同命名属性值赋值给另一个实体
        /// </summary>
        /// <typeparam name="T">数据源实体类型</typeparam>
        /// <typeparam name="TT">待赋值实体类型</typeparam>
        /// <param name="source">数据源实体</param>
        /// <param name="fill">待赋值实体</param>
        /// <param name="excludes">被排除赋值的字段名称</param>
        public static void AutoCopyFields<T, TT>(this T source, TT fill, List<string>? excludes = null)
        {
            string description = string.Empty;
            var sourceType = source?.GetType();
            var sourceProps = sourceType?.GetProperties();

            var fillType = fill?.GetType();
            var fillProps = fillType?.GetProperties();

            foreach (var item in sourceProps)
            {
                if (excludes == null || !excludes.Contains(item.Name))
                {
                    var fProps = fillProps?.Where(n => n.Name == item.Name);
                    if (fProps != null && fProps.Any())
                    {
                        var fProp = fProps.First();
                        if (fProp.CanWrite)
                        {
                            if (item.GetValue(source) == null)
                            {
                                fProp.SetValue(fill, null);
                            }
                            else
                            {
                                var dataType = Type.GetType(fProp?.PropertyType.FullName);
                                if (dataType?.Name == "Nullable`1")
                                {
                                    dataType = Nullable.GetUnderlyingType(dataType);
                                }

                                fProp.SetValue(fill, Convert.ChangeType(item.GetValue(source), dataType));
                            }
                        }
                    }
                }
            }
        }

        #endregion 将一个实体相同命名属性值赋值给另一个实体
    }
}
