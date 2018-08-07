using System;
using System.Collections.Generic;

namespace CapitolFarmsProject.Models
{
    public class Horse
    {
        public int HorseId {get; set;}
        public string HorseName {get; set;}
        public int Location {get; set;}
        public List<HorseGrain> HorseGrains {get; set;}
    }
}