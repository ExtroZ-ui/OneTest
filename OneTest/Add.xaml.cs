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
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    /// 

    public partial class Add : Window
    {
        ApplicationContext db;
        public Add()
        {
            InitializeComponent();
            db = new ApplicationContext();
        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }

        private void saveNew_Click(object sender, RoutedEventArgs e)
        {
            Car car = new Car()
            {
                Organization = textOrgan.Text,
                Mark = textMarka.Text,
                Number = textNomer.Text,
                Add = "*" + textStrex.Text + "*"
            };

            db.Cars.Add(car);
            db.SaveChanges();

            new MainWindow().Show();
            Close();

        }
    }
}
