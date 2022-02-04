using InveTime.DataEntities.Entities.Base;

namespace InveTime.DataEntities.Entities
{
    public class CategorySearchWord : NamedEntity
    {
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
