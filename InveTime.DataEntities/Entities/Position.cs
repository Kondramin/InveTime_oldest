using InveTime.DataEntities.Entities.Base;
using System.Collections.Generic;

namespace InveTime.DataEntities.Entities
{
    public class Position : NamedEntity
    {
        public int AccessLevel { get; set; }



        public ICollection<Employee> Employees { get; set; }
    }
}
