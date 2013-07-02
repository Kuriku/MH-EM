using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MH_EM.Models
{
    public class ArmorPart
    {
        string name;                                                            //name of armor piece
        Enums.EquipSlot equip_slot;                                             //head,chest,arms,waist or legs
        int jewel_slots;                                                        //0-3 jewel slots
        Dictionary<string, int> resistances = new Dictionary<string,int>();     //fire, water, ice, thunder, dragon resistance
        int defense;                                                            //defense value
        Dictionary<string, int> skills = new Dictionary<string, int>();         //1-5 skills granted
        Dictionary<string, int> materials = new Dictionary<string, int>();      //1-4 materials required
        Enums.Armortype armor_type;                                             //blademaster or gunner
    }
}
