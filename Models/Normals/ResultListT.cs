namespace Models
{
    public class ResultList<T> : Result
    {
        /// <summary>
        /// 实体类
        /// </summary>
        public List<T>? Data { get; set; }
    }
}
