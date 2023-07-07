namespace DataBase.Entitys
{
    public class Log: EntityBase
    {
        public string? subject { get; set; }
        public string? message { get; set; }
        public string? creator { get; set; }
    }
}