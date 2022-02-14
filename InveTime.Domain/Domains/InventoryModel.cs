using InveTime.Domain.Domains.Base;
using System;
using System.Collections.ObjectModel;

namespace InveTime.Domain.Domains
{
    public class InventoryModel : EntityModel
    {
        public DateTime EventDate { get; set; }
        public bool OpenToModifi { get; set; } = true;



        public ObservableCollection<EmployeeModel> EventStaff { get; set; }



        public int? MarketId { get; set; }
        public string MarketName { get; set; }



        public ObservableCollection<ProductInventedModel> ProductInventeds { get; set; }
    }
}
