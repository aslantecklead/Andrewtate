using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Security.Cryptography;
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
    /// Обращение к таблице "Станции" и "Поезда" в БД. Вывод списков в визульные элементы 
    /// "DataGrid", "CpmboBox", логика для CRUD действий над таблицей "Станции" - Stations
    /// </summary>
    public partial class UserWindow : Window
    {
        RailwaysEntities db = new RailwaysEntities();
        public UserWindow()
        {
            InitializeComponent();
            Load_Data();
        }

        // Инициализация БД, и вывод списка станцией в DataGrid
        private void Load_Data()
        {
            var stations = db.Stantion.ToList();
            dgStations.SelectedValuePath = "ID_Station";
            dgStations.ItemsSource = stations;
            dgStations.SelectionMode = DataGridSelectionMode.Single;

            var trains = db.Train.ToList();
            cbTrain.ItemsSource = trains;
            cbTrain.SelectedIndex = 0;

            cbTrain.SelectedValuePath = "ID_Train";
            cbTrain.DisplayMemberPath = "Name";

            //Статистика
            Count.Text = db.Train.Count().ToString();
            Console.WriteLine($"Всего хоршего {Count.Text}");
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

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            string hash = BitConverter.ToString(MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(tbName.Text)));
            Stantion stantion = new Stantion
            {
                Name = hash,
                Town = tbTown.Text,
                Size = int.Parse(tbSize.Text),
                Traint_ID = (int)cbTrain.SelectedValue,
            };
            db.Stantion.Add(stantion);
            try
            {
                db.SaveChanges();

            } catch (DbUpdateException ex)
            {
                MessageBox.Show("Ошибка сохранения данных" + ex.InnerException.Message);
                Console.WriteLine(ex.InnerException.Message);
            }
            Load_Data();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (dgStations.SelectedItem != null)
            {
                Stantion selectedStation = (Stantion)dgStations.SelectedItem;
                selectedStation.Name = tbName.Text;
                selectedStation.Town = tbTown.Text;
                selectedStation.Size = int.Parse(tbSize.Text);
                selectedStation.Traint_ID = (int)cbTrain.SelectedValue;

                try
                {
                    db.SaveChanges();
                    MessageBox.Show("Данные успешно обновлены");
                }
                catch (DbUpdateException ex)
                {
                    MessageBox.Show("Ошибка обновления данных: " + ex.InnerException.Message);
                    Console.WriteLine(ex.InnerException.Message);
                }

                Load_Data();
            }
            else
            {
                MessageBox.Show("Выберите станцию для редактирования");
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (dgStations.SelectedItem != null)
            {
                Stantion selectedStation = (Stantion)dgStations.SelectedItem;
                db.Stantion.Remove(selectedStation);

                try
                {
                    db.SaveChanges();
                    MessageBox.Show("Станция успешно удалена");
                }
                catch (DbUpdateException ex)
                {
                    MessageBox.Show("Ошибка удаления данных: " + ex.InnerException.Message);
                    Console.WriteLine(ex.InnerException.Message);
                }

                Load_Data();
            }
            else
            {
                MessageBox.Show("Выберите станцию для удаления");
            }
        }
    }
}
