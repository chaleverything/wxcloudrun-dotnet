namespace Models
{
    public class Result<T> : Result
    {
        /// <summary>
        /// 实体类
        /// </summary>
        public T? Data { get; set; }
    }
}
