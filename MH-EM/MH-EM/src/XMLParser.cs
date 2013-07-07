using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using MH_EM.Models;

namespace MH_EM.src
{
    public class XMLParser
    {

        public static void ParseArmor(string file, List<ArmorPart> slot)
        {

            XDocument root = XDocument.Load(file);              //load xml file

            var armorParts = root.Elements().Elements();
                     
            foreach (var part in armorParts)                    // enumerate through all armor_part entries
            {
                ArmorPart armorPart = new ArmorPart();                                                                                  //create new ArmorPart object

                armorPart.Name = part.Element("name").Value;                                                                   //copy name attribute from xml file

                armorPart.Jewel_slots = Convert.ToInt32(part.Element("jewel_slots").Value);                                             //get jewel_slot attribute from xml and convert to int
                armorPart.Defence = Convert.ToInt32(part.Element("defence").Value);                                                     //same as jewel slots

                armorPart.Equip_slot = (Enums.EquipSlot)Enum.Parse(typeof(Enums.EquipSlot), part.Element("slot").Value, true);         //fetch slot value from xml file and parses it to corresponding enum value
                armorPart.Armor_type = (Enums.ArmorType)Enum.Parse(typeof(Enums.ArmorType), part.Element("armor_type").Value, true);   //parameter true is to ignore case sensitivity

                var resistances = part.Element("resistances");                                                                         //make all resistance childs accessible
                armorPart.Resistances.Add("fire", Convert.ToInt32(resistances.Element("fire").Value));                                 //add each resistance to the dictionary
                armorPart.Resistances.Add("water", Convert.ToInt32(resistances.Element("water").Value));
                armorPart.Resistances.Add("ice", Convert.ToInt32(resistances.Element("ice").Value));
                armorPart.Resistances.Add("thunder", Convert.ToInt32(resistances.Element("thunder").Value));
                armorPart.Resistances.Add("dragon", Convert.ToInt32(resistances.Element("dragon").Value));

                var skills = part.Element("skills").Elements("skill");                                                                  //create enumerable collection of skills
                foreach (var skill in skills)                                                                                           //for every skill add name,value pair to dict
                {
                    armorPart.Skills.Add(skill.Element("name").Value, Convert.ToInt32(skill.Element("points").Value));
                }

                var materials = part.Element("materials").Elements("material");                                                         //same as skills
                foreach (var material in materials)
                {
                    armorPart.Materials.Add(material.Element("name").Value, Convert.ToInt32(material.Element("amount").Value));
                }

                slot.Add(armorPart);

            }
        }

        public static void ParseSets(string file, List<ArmorSet> setlist)       //parses saved sets from xml file
        {

            XDocument root = XDocument.Load(file);              //load xml file

            var sets = root.Elements().Elements();

            foreach (var set in sets)                    // enumerate through all set entries
            {

                ArmorSet armorset = new ArmorSet();

                armorset.Title = set.Element("name").Value;                                     //extract title from xml file
                armorset.Head = LookupArmorPiece("head", set.Element("head").Value);            //lookup armor pieces by name from already parsed armor file
                armorset.Chest = LookupArmorPiece("chest", set.Element("chest").Value);
                armorset.Arms = LookupArmorPiece("arms", set.Element("arms").Value);
                armorset.Head = LookupArmorPiece("waist", set.Element("waist").Value);
                armorset.Head = LookupArmorPiece("legs", set.Element("legs").Value);

                setlist.Add(armorset);

            }


        }

        public static void ParseJewels(string file, List<Jewel> jewels)
        {
        }

        public static void ParseSkills(string file, List<Jewel> jewels)
        {
        }


        public static ArmorPart LookupArmorPiece(string slot, string name)      //returns ArmorPiece object of an armorpiece by slot and name, null if not in list
        {

            List<ArmorPart> partlist;
            ArmorPart piece = null;

            switch (slot)
            {
                case "head":
                    partlist = App.heads;
                    break;
                case "chest":
                    partlist = App.chests;
                    break;
                case "arms":
                    partlist = App.arms;
                    break;
                case "waist":
                    partlist = App.waists;
                    break;
                case "legs":
                    partlist = App.legs;
                    break;
                default:
                    partlist = null;
                    break;
            }

            foreach (ArmorPart item in partlist)
            {
                if (item.Name == name)
                    piece = item;
            }

            return piece;
        }

    }
}
