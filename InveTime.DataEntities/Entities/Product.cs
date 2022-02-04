using InveTime.DataEntities.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace InveTime.DataEntities.Entities
{
    public class Product : NamedEntity
    {
        public string Barcode { get; set; }
        public string VendorCode { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? Price { get; set; }



        public int? CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
