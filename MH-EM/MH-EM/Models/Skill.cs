using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MH_EM.Models
{
    public class Skill
    {

        public string name { get; set; }
        public Dictionary<string, int> effects { get; set; }

        public Skill()
        {

            this.name = "";
            this.effects = new Dictionary<string, int>();
        }


    }
}
