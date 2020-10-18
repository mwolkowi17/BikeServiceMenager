using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeServiceMenager.Models
{
    public class BikeServiceViewModel
    {
        public List<Client> ClientList { get; set; }
        public List<Bike> BikeList { get; set; }
        public List<ServiceOrder> ServiceOrderList { get; set; }
        public List<ServiceHistory> ServiceHistoryList { get; set; }
        public List<ServiceAction> ServiceActionList { get; set; }

    }
}
