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

namespace OneTest
{
    /// <summary>
    /// Логика взаимодействия для Print.xaml
    /// </summary>



    public partial class Print : Window
    {

        ApplicationContext db;
        public Print(int index)
        {
            InitializeComponent();
            db = new ApplicationContext();
            db.Cars.Load();


            dynamic temp = db.Cars.Where(i => i.id == index);

            foreach (Car t in temp)
            {
                nameBd.Content = t.Organization.ToString();
                markBd.Content = t.Mark.ToString();
                numbereBd.Content = t.Number.ToString();
                addBd.Content = t.Add.ToString();
            }


        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void PrintAll_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog p = new PrintDialog();
            if(p.ShowDialog() == true)
            {
                p.PrintVisual(grid, "Печать");
            }
        }
    }
}
