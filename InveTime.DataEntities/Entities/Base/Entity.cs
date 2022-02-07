using InveTime.Interfaces.Base.Entity;

namespace InveTime.DataEntities.Entities.Base
{
    public abstract class Entity : IEntity
    {
        public int Id { get; set; }
    }
}
