using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeServiceMenager.Models
{
    public class ServiceOrder
    {
        public int ServiceOrderId { get; set; }
        public Bike BikeToService { get; set; }
        public Client BikeToServiceOwner { get; set; }
        public DateTime DateOfOrderOpen { get; set; }
        public ServiceAction ActionToDo { get; set; }
        
    }
}
