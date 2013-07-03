using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MH_EM.Models
{


    public class ArmorSet
    {

        string title { get; set; }
        ArmorPart head { get; set; }
        ArmorPart chest { get; set; }
        ArmorPart arms { get; set; }
        ArmorPart waist { get; set; }
        ArmorPart legs { get; set; }

    }
}
