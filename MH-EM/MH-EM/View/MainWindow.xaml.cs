using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MH_EM.ViewModels;

namespace MH_EM.View{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window{
        public EquipmentManagerViewModel EquipmentManagerViewModel { get; private set; }

        public MainWindow(){
            EquipmentManagerViewModel = new EquipmentManagerViewModel();
            this.DataContext = EquipmentManagerViewModel;
            InitializeComponent();
        }
    }
}
