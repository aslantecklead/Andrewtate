using Andrewtate.Windows.Users;
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

namespace Andrewtate.Windows
{
    /// <summary>
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class Auth : Window
    {
        RailwaysEntities db = new RailwaysEntities();
        public Auth()
        {
            InitializeComponent();
            Load_data();
        }

        private void Load_data()
        {
            var userList = db.Employee.ToList();

        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            var userList = db.Employee.FirstOrDefault(x => x.Login == tbLogin.Text && x.Password == tbPassword.Text);
            if (userList != null)
            {
               switch (userList.Role_ID)
                {
                    case 1:
                        AdminWindow adminWindow = new AdminWindow();
                        adminWindow.Show();
                        Close();
                        break;
                    case 2:
                        UserWindow userWindow = new UserWindow();
                        userWindow.Show();
                        Close();
                        break;
                    default:
                        MessageBox.Show("Нет такого юзера!");
                        break;
                }
            }
        }
    }
}
