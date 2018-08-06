using System;
using System.Collections.Generic;

namespace Models.Horse
{
    public class Horse
    {
        public int HorseId {get; set;}
        public string HorseName {get; set;}
        public int Location {get; set;}
        public List<Grain> Grains {get; set;}
    }
}