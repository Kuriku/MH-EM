using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MH_EM.Models
{
    public class Jewel
    {

        public string Name { get; set; }
        public Dictionary<string, int> Skills { get; set; }

        public Jewel()
        {

            this.Name = "";
            this.Skills = new Dictionary<string, int>();
        }


    }
}
