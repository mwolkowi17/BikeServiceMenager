using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeServiceMenager.Models
{
    public class ServiceAction
    {
        public int ServiceActionId { get; set; }
        public string ActionName { get; set; }
        public int Price { get; set; }
        public int ManHour { get; set; }
    }
}
