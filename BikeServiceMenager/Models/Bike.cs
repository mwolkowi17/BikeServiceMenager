﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeServiceMenager.Models
{
    public class Bike
    {
        public int BikeId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string YearOfProduction { get; set; }
        public Client Owner { get; set; }
        public BikeType Type { get; set; }
    }

    public enum BikeType
    {
        mountain, tourist, bmx, road
    }

}
