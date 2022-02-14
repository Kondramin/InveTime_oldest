using InveTime.Interfaces.Base.Entity;

namespace InveTime.Domain.Domains.Base
{
    public abstract class EntityModel : IEntity
    {
        public int Id { get; set; }
    }
}
