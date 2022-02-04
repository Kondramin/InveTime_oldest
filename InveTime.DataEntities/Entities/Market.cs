using InveTime.DataEntities.Entities.Base;
using System.Collections.Generic;

namespace InveTime.DataEntities.Entities
{
    public class Market : NamedEntity
    {
        public string Location { get; set; }



        public ICollection<Employee> Staff { get; set; }



        public ICollection<Inventory> Inventories { get; set; }
    }
}
