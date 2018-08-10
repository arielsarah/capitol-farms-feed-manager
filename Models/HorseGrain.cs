using System;
using System.Collections.Generic;

namespace CapitolFarmsProject.Models
{
    public class HorseGrain
    {
        public int HorseGrainId {get; set;}
        public decimal Amount {get; set;}
        public bool AMReport {get; set;}
        public bool PMReport {get; set;}
        public Horse Horse {get; set;}
        public Grain Grain {get; set;}
    }
}