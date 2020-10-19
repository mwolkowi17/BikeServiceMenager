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
        public ServiceAction ActionToDo1 { get; set; }
        public ServiceAction ActionToDo2 { get; set; }
        public ServiceAction ActionToDo3 { get; set; }
        public ServiceAction ActionToDo4 { get; set; }
        public ServiceAction ActionToDo5 { get; set; }
        public string AditionalNotes { get; set; }
    }
}
