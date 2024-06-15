using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static System.Collections.Specialized.BitVector32;

namespace Andrewtate.Windows.Users
{
    /// <summary>
    /// Логика взаимодействия для UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        RailwaysEntities db = new RailwaysEntities();
        public UserWindow()
        {
            InitializeComponent();
            Load_Data();
        }

        private void Load_Data()
        {
            var stations = db.Stantion.ToList();
            dgStations.SelectedValuePath = "ID_Station";
            dgStations.ItemsSource = stations;
            dgStations.SelectionMode = DataGridSelectionMode.Single;

            var trains = db.Train.ToList();
            cbTrain.ItemsSource = trains;
            cbTrain.SelectedIndex = 0;

            cbTrain.SelectedValuePath = "ID";
            cbTrain.DisplayMemberPath = "Name";

            Count.Text = db.Train.Count().ToString();
        }

        private void dgStations_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgStations.SelectedItem != null)
            {
                Stantion selectedTrains = (Stantion)dgStations.SelectedItem;
                tbName.Text = selectedTrains.Name;
                tbSize.Text = selectedTrains.Size.ToString();
                tbTown.Text = selectedTrains.Town;
                cbTrain.SelectedItem = selectedTrains.Train;
            }
        }
    }
}
