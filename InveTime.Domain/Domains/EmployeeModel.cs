using InveTime.Domain.Domains.Base;

namespace InveTime.Domain.Domains
{
    public class EmployeeModel : NamedEntityModel
    {
        public string SecondName { get; set; }

        public string Patronymic { get; set; }

        public string Email { get; set; }

        public string Location { get; set; }

        public string Phone { get; set; }


        public int? MarketId { get; set; }
        public string MarketName { get; set; }



        public int? PositionId { get; set; }
        public PositionModel Position { get; set; }



        public string GetFIO() => Name + " " + SecondName + " " + Patronymic;

    }
}
