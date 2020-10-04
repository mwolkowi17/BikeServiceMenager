using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeServiceMenager.Models
{
    public class Client
    {
        public int ClientId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime YearOfBecameClient { get; set; }
        
    }
}
