using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MH_EM.Models
{
    public class ArmorPart
    {

        public string name { get; set; }                                                            //name of armor piece
        public Enums.EquipSlot equip_slot { get; set; }                                             //head,chest,arms,waist or legs
        public int jewel_slots { get; set; }                                                        //0-3 jewel slots
        public Dictionary<string, int> resistances{ get; set; }                                     //fire, water, ice, thunder, dragon resistance
        public int defence { get; set; }                                                            //defence value
        public Dictionary<string, int> skills{ get; set; }                                          //1-5 skills granted
        public Dictionary<string, int> materials { get; set; }                                      //1-4 materials required
        public Enums.ArmorType armor_type { get; set; }                                             //blademaster or gunner


        public ArmorPart()
        {

            this.name = "";
            this.equip_slot = Enums.EquipSlot.head;
            this.jewel_slots = 0;
            this.resistances = new Dictionary<string,int>();
            this.defence = 0;
            this.skills = new Dictionary<string, int>();
            this.materials = new Dictionary<string, int>();
            this.armor_type = Enums.ArmorType.Blademaster;

        }


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
