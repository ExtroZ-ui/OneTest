using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace OneTest.form
{
    /// <summary>
    /// Логика взаимодействия для Serch.xaml
    /// </summary>
    public partial class Serch : Window
    {
        ApplicationContext db;
        public Serch()
        {
            InitializeComponent();
            db = new ApplicationContext();
            db.Cars.Load();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void serc_Click(object sender, RoutedEventArgs e)
        {

            BdCars.ItemsSource = db.Cars.Local.ToBindingList().Where(a => a.Organization.StartsWith(textSercOrg.Text));
            BdCars.ItemsSource = db.Cars.Local.ToBindingList().Where(a => a.Mark.StartsWith(textSercMark.Text));
            BdCars.ItemsSource = db.Cars.Local.ToBindingList().Where(a => a.Number.StartsWith(textSercnumber.Text));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void textSercOrg_TextChanged(object sender, TextChangedEventArgs e)
        {
            BdCars.ItemsSource = db.Cars.Local.ToBindingList().Where(a => a.Organization.StartsWith(textSercOrg.Text));
        }

        private void textSercMark_TextChanged(object sender, TextChangedEventArgs e)
        {
            BdCars.ItemsSource = db.Cars.Local.ToBindingList().Where(a => a.Mark.StartsWith(textSercMark.Text));
        }

        private void textSercnumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            BdCars.ItemsSource = db.Cars.Local.ToBindingList().Where(a => a.Number.StartsWith(textSercnumber.Text));
        }
    }
}
