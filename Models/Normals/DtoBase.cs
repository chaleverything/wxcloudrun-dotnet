using AutoMapper.Configuration.Annotations;

namespace Models
{
    public abstract class DtoBase
    {
        [Ignore]
        public long id { get; set; }

        public DateTime? creationTime { get; set; }
    }
}
