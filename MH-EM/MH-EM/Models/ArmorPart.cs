using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MH_EM.Models
{
    public class ArmorPart
    {

        public string name;                                                            //name of armor piece
        public Enums.EquipSlot equip_slot;                                             //head,chest,arms,waist or legs
        public int jewel_slots;                                                        //0-3 jewel slots
        public Dictionary<string, int> resistances = new Dictionary<string,int>();     //fire, water, ice, thunder, dragon resistance
        public int defence;                                                            //defence value
        public Dictionary<string, int> skills = new Dictionary<string, int>();         //1-5 skills granted
        public Dictionary<string, int> materials = new Dictionary<string, int>();      //1-4 materials required
        public Enums.ArmorType armor_type;                                             //blademaster or gunner


        public override string ToString()                                               //override default toString() for nice console output, because why not!
        {

            string output;
            output = " Name: \n\t" + this.name + "\n Equip Slot: \n\t" + this.equip_slot + "\n Jewel Slots: \n\t" + this.jewel_slots + "\n Resistances: \n";

            foreach (var pair in this.resistances)
            {
                output = output + "\t" + pair.Key + ": " + pair.Value + "\n";
            }

            output = output + " Defence: \n\t" + this.defence + "\n Skills: \n";

            foreach (var pair in this.skills)
            {
                output = output + "\t" + pair.Key + ": " + pair.Value + "\n";
            }

            output = output + " Materials: \n";

            foreach (var pair in this.materials)
            {
                output = output + "\t" + pair.Key + ": " + pair.Value + "\n";
            }

            output = output + " Armor Type: \n\t" + this.armor_type;

            return output;

        }
    }
}
