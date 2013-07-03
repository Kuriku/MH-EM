using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MH_EM.Models
{
    public class Skill
    {

        public string Name { get; set; }
        public Dictionary<string, int> Effects { get; set; }

        public Skill()
        {

            this.Name = "";
            this.Effects = new Dictionary<string, int>();
        }


    }
}
