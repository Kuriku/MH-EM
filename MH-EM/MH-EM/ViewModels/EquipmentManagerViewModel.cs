using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using MH_EM.Models;
using MH_EM.src;

namespace MH_EM.ViewModels {
    public class EquipmentManagerViewModel {
        public ArmorPart SelectedHead { get; set; }

        public ObservableCollection<ArmorPart> Heads { get; private set; }
        public ObservableCollection<ArmorPart> Chests { get; private set; }
        public ObservableCollection<ArmorPart> Arms { get; private set; }
        public ObservableCollection<ArmorPart> Waists { get; private set; }
        public ObservableCollection<ArmorPart> Legs { get; private set; }

        public EquipmentManagerViewModel() {
            Heads = new ObservableCollection<ArmorPart>();
            Chests = new ObservableCollection<ArmorPart>();
            Arms = new ObservableCollection<ArmorPart>();
            Waists = new ObservableCollection<ArmorPart>();
            Legs = new ObservableCollection<ArmorPart>();

            LoadEquipmentParts();
        }

        private void LoadEquipmentParts() {
            // @TODO Change return type of the parser to generic ICollection and add a return type so the parser can be reused.
            //Heads = XMLParser.ParseArmor("../../src/Data/heads.xml");
            //Chests = XMLParser.ParseArmor("../../src/Data/chests.xml");
            //Arms = XMLParser.ParseArmor("../../src/Data/arms.xml");
            //Waists = XMLParser.ParseArmor("../../src/Data/waists.xml");
            //Legs = XMLParser.ParseArmor("../../src/Data/legs.xml");

            // Filling the heads (only for testing purposes!)
            Console.WriteLine(App.heads.Count);
            foreach (ArmorPart armorPart in App.heads) {
                Heads.Add(armorPart);
                Console.WriteLine(armorPart.Name);
            }
        }
    }
}
