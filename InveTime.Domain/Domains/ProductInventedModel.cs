using InveTime.Domain.Domains.Base;

namespace InveTime.Domain.Domains
{
    public class ProductInventedModel : EntityModel
    {
        public int AmountData { get; set; }
        public int AmountFact { get; set; }



        public bool Re_Grading { get; set; }



        public int? ProductInfoId { get; set; }
        public ProductModel ProductInfo { get; set; }



        public int? InventoryId { get; set; }
        
    }
}
