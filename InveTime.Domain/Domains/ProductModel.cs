using InveTime.Domain.Domains.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace InveTime.Domain.Domains
{
    public class ProductModel : NamedEntityModel
    {
        public string Barcode { get; set; }
        public string VendorCode { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? Price { get; set; }



        public int? CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
