using InveTime.DataEntities.Entities.Base;
using System.Collections.Generic;

namespace InveTime.DataEntities.Entities
{
    public class Category : NamedEntity
    {
        public ICollection<Product> Products { get; set; }
        public ICollection<CategorySearchWord> CategorySearchWords { get; set; }
    }
}
