using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CapitolFarmsProject.Models
{
    public class Horse
    {
        public int HorseId {get; set;}
        public string HorseName {get; set;}
        public int Location {get; set;}
        public List<HorseGrain> HorseGrains {get; set;}
        
        [Column(TypeName = "text")]
        public string Notes {get; set;}
        public byte[] Photo {get; set;}
    }
}