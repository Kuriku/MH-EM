using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using System.Diagnostics;
using System.Threading;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using MH_EM.View;
using MH_EM.Models;

namespace MH_EM
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private const int MINIMUM_SPLASH_TIME = 1400; // in Miliseconds
        private const int SPLASH_FADE_TIME = 600;     // in Miliseconds

        public static List<ArmorPart> heads = new List<ArmorPart>();
        public static List<ArmorPart> chests = new List<ArmorPart>();
        public static List<ArmorPart> arms = new List<ArmorPart>();
        public static List<ArmorPart> waists = new List<ArmorPart>();
        public static List<ArmorPart> legs = new List<ArmorPart>();


        protected override void OnStartup(StartupEventArgs e) {
            ////base.OnStartup(e);

            // Step 1 - Load the splash screen
            SplashScreen splash = new SplashScreen("src/Images/mhem_logo.png");
            splash.Show(false, true);   // param: autoclose, topmost

            // Step 2 - Start a stop watch
            Stopwatch timer = new Stopwatch();
            timer.Start();

            // Step 3 - Load your windows but don't show it yet
            base.OnStartup(e);

            ParseArmor("../../src/Data/heads.xml", heads);
            ParseArmor("src/Data/chests.xml", chests);
            ParseArmor("src/Data/arms.xml", arms);
            ParseArmor("src/Data/waists.xml", waists);
            ParseArmor("src/Data/legs.xml", legs);
            

            MainWindow main = new MainWindow();

            // Step 4 - Make sure that the splash screen lasts at least two seconds
            timer.Stop();
            int remainingTimeToShowSplash = MINIMUM_SPLASH_TIME - (int)timer.ElapsedMilliseconds;
            if (remainingTimeToShowSplash > 0) {
                Thread.Sleep(remainingTimeToShowSplash);
            }

            // Step 5 - show the page
            splash.Close(TimeSpan.FromMilliseconds(SPLASH_FADE_TIME));
            main.Show();
        }

        private void ParseArmor(string file, List<ArmorPart> slot) {

            XDocument root = XDocument.Load(file);              //load xml file

            var armorParts = root.Elements("armor_parts");       //returns enumerable collection of armor_part entries in xml file

            

            foreach (var part in armorParts)                    // enumerate through all armor_part entries
            {

                ArmorPart armorPart = new ArmorPart();                                                                                  //create new ArmorPart object

                
                armorPart.name = (string)part.Element("name").Value;                                                                   //copy name attribute from xml file


                armorPart.jewel_slots = Convert.ToInt32(part.Element("jewel_slots").Value);                                             //get jewel_slot attribute from xml and convert to int
                armorPart.defence = Convert.ToInt32(part.Element("defence").Value);                                                     //same as jewel slots

                armorPart.equip_slot = (Enums.EquipSlot)Enum.Parse(typeof(Enums.EquipSlot), part.Element("slot").Value, true);         //fetch slot value from xml file and parses it to corresponding enum value
                armorPart.armor_type = (Enums.ArmorType)Enum.Parse(typeof(Enums.ArmorType), part.Element("armor_type").Value, true);   //parameter true is to ignore case sensitivity

                var resistances = part.Element("resistances");                                                                         //make all resistance childs accessible
                armorPart.resistances.Add("fire", Convert.ToInt32(resistances.Element("fire").Value));                                 //add each resistance to the dictionary
                armorPart.resistances.Add("water", Convert.ToInt32(resistances.Element("water").Value));
                armorPart.resistances.Add("ice", Convert.ToInt32(resistances.Element("ice").Value));
                armorPart.resistances.Add("thunder", Convert.ToInt32(resistances.Element("thunder").Value));
                armorPart.resistances.Add("dragon", Convert.ToInt32(resistances.Element("dragon").Value));

                var skills = part.Element("skills").Elements("skill");                                                                  //create enumerable collection of skills
                foreach (var skill in skills)                                                                                           //for every skill add name,value pair to dict
                {
                    armorPart.skills.Add(skill.Element("name").Value, Convert.ToInt32(skill.Element("points").Value));
                }

                var materials = part.Element("materials").Elements("material");                                                         //same as skills
                foreach (var material in materials)
                {
                    armorPart.materials.Add(material.Element("name").Value, Convert.ToInt32(material.Element("amount").Value));
                }

                slot.Add(armorPart);

            }

            
            


        }
    }
}
