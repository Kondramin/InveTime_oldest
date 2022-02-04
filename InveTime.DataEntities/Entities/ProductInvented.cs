using InveTime.DataEntities.Entities.Base;

namespace InveTime.DataEntities.Entities
{
    public class ProductInvented : Entity
    {
        public int AmountData { get; set; }
        public int AmountFact { get; set; }



        public bool Re_Grading { get; set; }



        public int? ProductInfoId { get; set; }
        public Product ProductInfo { get; set; }



        
        public int? InventoryId { get; set; }
        public Inventory Inventory { get; set; }
    }
}
