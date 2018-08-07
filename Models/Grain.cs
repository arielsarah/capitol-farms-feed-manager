using System.Collections.Generic;

namespace CapitolFarmsProject.Models
{
    public class Grain
    {
        public int GrainId {get; set;}
        public string GrainName {get; set;}
        public List<Horse> Horses {get; set;}
        public decimal amount {get; set;}
    }
}