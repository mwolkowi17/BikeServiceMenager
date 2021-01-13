using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeServiceMenager.Models
{
    public class ServiceHistory
    {
        public int ServiceHistoryId { get; set; }
        public ServiceOrder ServiceOrderHistory { get; set; }

       public ServiceHistory()
        {

        }

       public ServiceHistory(ServiceOrder order)
        {
            ServiceOrderHistory = order;
        }
    }
}
