using InveTime.DataEntities.Entities.Base;
using System;
using System.Collections.Generic;

namespace InveTime.DataEntities.Entities
{
    public class Inventory : Entity
    {
        public DateTime EventDate { get; set; }
        public bool OpenToModifi { get; set; } = true;



        public ICollection<Employee> EventStaff { get; set; }



        public int? MarketId { get; set; }
        public Market Market { get; set; }



        public ICollection<ProductInvented> ProductInventeds { get; set; }

    }
}
