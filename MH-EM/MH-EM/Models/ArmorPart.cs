using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MH_EM.Models
{
    public class ArmorPart
    {

        public string Name { get; set; }                                                            //name of armor piece
        public Enums.EquipSlot Equip_slot { get; set; }                                             //head,chest,arms,waist or legs
        public int Jewel_slots { get; set; }                                                        //0-3 jewel slots
        public Dictionary<string, int> Resistances{ get; set; }                                     //fire, water, ice, thunder, dragon resistance
        public int Defence { get; set; }                                                            //defence value
        public Dictionary<string, int> Skills{ get; set; }                                          //1-5 skills granted
        public Dictionary<string, int> Materials { get; set; }                                      //1-4 materials required
        public Enums.ArmorType Armor_type { get; set; }                                             //blademaster or gunner


        public ArmorPart()
        {

            this.Name = "";
            this.Equip_slot = Enums.EquipSlot.head;
            this.Jewel_slots = 0;
            this.Resistances = new Dictionary<string,int>();
            this.Defence = 0;
            this.Skills = new Dictionary<string, int>();
            this.Materials = new Dictionary<string, int>();
            this.Armor_type = Enums.ArmorType.Blademaster;

        }


        public override string ToString()                                               //override default toString() for nice console output, because why not!
        {

            string output;
            output = " Name: \n\t" + this.Name + "\n Equip Slot: \n\t" + this.Equip_slot + "\n Jewel Slots: \n\t" + this.Jewel_slots + "\n Resistances: \n";

            foreach (var pair in this.Resistances)
            {
                output = output + "\t" + pair.Key + ": " + pair.Value + "\n";
            }

            output = output + " Defence: \n\t" + this.Defence + "\n Skills: \n";

            foreach (var pair in this.Skills)
            {
                output = output + "\t" + pair.Key + ": " + pair.Value + "\n";
            }

            output = output + " Materials: \n";

            foreach (var pair in this.Materials)
            {
                output = output + "\t" + pair.Key + ": " + pair.Value + "\n";
            }

            output = output + " Armor Type: \n\t" + this.Armor_type;

            return output;

        }
    }
}
