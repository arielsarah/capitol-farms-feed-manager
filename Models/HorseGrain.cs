using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CapitolFarmsProject.Models
{
    public partial class HorseGrain
    {
        public int HorseGrainId {get; set;}

        [Display(Name="Number of Scoops")]
        public decimal Amount {get; set;}
        public bool AMReport {get; set;}
        public bool PMReport {get; set;}
        public Horse Horse {get; set;}
        public int HorseId {get; set;}
        public Grain Grain {get; set;}
        public int GrainId {get; set;}
    }
}