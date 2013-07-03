using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MH_EM.Models
{


    public class ArmorSet
    {

        public string Title { get; set; }
        public ArmorPart Head { get; set; }
        public ArmorPart Chest { get; set; }
        public ArmorPart Arms { get; set; }
        public ArmorPart Waist { get; set; }
        public ArmorPart Legs { get; set; }


        public ArmorSet()
        {

            this.Title = "";
            this.Head = new ArmorPart();
            this.Chest = new ArmorPart();
            this.Arms = new ArmorPart();
            this.Waist = new ArmorPart();
            this.Legs = new ArmorPart();

        }

    }




}
