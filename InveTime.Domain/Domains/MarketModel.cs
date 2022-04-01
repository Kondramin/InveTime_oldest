using InveTime.Domain.Domains.Base;
using System.Collections.ObjectModel;

namespace InveTime.Domain.Domains
{
    public class MarketModel : NamedEntityModel
    {
        public string Location { get; set; }



        public ObservableCollection<EmployeeModel> Staff { get; set; }

    }
}
