using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MH_EM.Models
{


    public class ArmorSet
    {

        public string title { get; set; }
        public ArmorPart head { get; set; }
        public ArmorPart chest { get; set; }
        public ArmorPart arms { get; set; }
        public ArmorPart waist { get; set; }
        public ArmorPart legs { get; set; }


        public ArmorSet()
        {

            this.title = "";
            this.head = new ArmorPart();
            this.chest = new ArmorPart();
            this.arms = new ArmorPart();
            this.waist = new ArmorPart();
            this.legs = new ArmorPart();

        }

    }




}
