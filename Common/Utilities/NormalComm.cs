namespace Common.Utilities
{
    public static class NormalComm
    {
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

        public static string BufferToBase64String(this byte[]? bytes)
        {
            if (bytes?.Length > 0)
            {
                return Convert.ToBase64String(bytes, 0, bytes.Length);
            }

            return string.Empty;
        }
    }
}
