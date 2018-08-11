using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CapitolFarmsProject.Models
{
    public class HorseGrainViewModel
    {
        [BindProperty]
        public HorseGrain HorseGrain {get; set;}
        public SelectList Horses {get; set;}
        public SelectList Grains {get; set;}

        public HorseGrainViewModel(){}

        public HorseGrainViewModel(CapitolFarmsProjectContext context, HorseGrain horseGrain=null)
        {
            HorseGrain = horseGrain;
            var horseQuery = from h in context.Horse
                                    orderby h.HorseName
                                    select h.HorseName;
            Horses = new SelectList(horseQuery.Distinct().ToList());
            var grainQuery = from g in context.Grain
                                    orderby g.GrainName
                                    select g.GrainName;
            Grains = new SelectList(grainQuery.Distinct().ToList());
        }
        
    }
}