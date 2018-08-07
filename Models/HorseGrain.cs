using System;
using System.Collections.Generic;

namespace CapitolFarmsProject.Models
{
    public class HorseGrain
    {
        public int HorseGrainId {get; set;}
        public decimal Amount {get; set;}
        public AMPM ReportTime {get; set;}
        
        public Horse Horse {get; set;}
        public Grain Grain {get; set;}
    }
}