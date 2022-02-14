using InveTime.Domain.Domains.Base;

namespace InveTime.Domain.Domains
{
    public class CategorySearchWordModel : NamedEntityModel
    {
        public int? CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
