using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CapitolFarmsProject.Models
{
    public class Horse
    {
        public int HorseId {get; set;}
        public string HorseName {get; set;}

        [Range(1, 19)]
        public int Location {get; set;}
        public ICollection<HorseGrain> HorseGrains {get; set;}
        
        [Column(TypeName = "text")]
        public string Notes {get; set;}
        public byte[] Photo {get; set;}
    }
}