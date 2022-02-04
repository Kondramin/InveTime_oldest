using InveTime.DataEntities.Entities.Base;
using System.Collections.Generic;

namespace InveTime.DataEntities.Entities
{
    public class Employee : NamedEntity
    {
        public string SecondName { get; set; }
        
        public string Patronymic { get; set; }
        
        public string Email { get; set; }
        
        public string Location { get; set; }
        
        public string Phone { get; set; }


        public int? MarketId { get; set; }
        public Market Market { get; set; }



        public int? PositionId { get; set; }
        public Position Position { get; set; }



        public int? PasswordId { get; set; }
        public Password Password { get; set; }




        public ICollection<Inventory> Inventories { get; set; }

    }
}
