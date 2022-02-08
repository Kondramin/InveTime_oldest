using InveTime.Interfaces.Base.Entity;

namespace InveTime.Domain.Domains.Base
{
    public abstract class EntityDto : IEntity
    {
        public int Id { get; set; }
    }
}
