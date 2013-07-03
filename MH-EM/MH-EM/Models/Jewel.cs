﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MH_EM.Models
{
    public class Jewel
    {

        public string name { get; set; }
        public Dictionary<string, int> skills { get; set; }

        public Jewel()
        {

            this.name = "";
            this.skills = new Dictionary<string, int>();
        }


    }
}
