using DocumentFormat.OpenXml.Drawing.Charts;
using OneTest.form;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Clipboard = System.Windows.Forms.Clipboard;
using DataFormats = System.Windows.Forms.DataFormats;
using DataGrid = System.Windows.Controls.DataGrid;

namespace OneTest
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    ///


    public partial class MainWindow : Window
    {

        ApplicationContext db;
        public MainWindow()
        {
          
            InitializeComponent();

            db = new ApplicationContext();
            db.Cars.Load();
            BdCars.ItemsSource = db.Cars.Local.ToBindingList();
        }

        

        private void Serch_click(object sender, RoutedEventArgs e)
        {
            new Serch().Show();

        }

        private void AddBasi_Click(object sender, RoutedEventArgs e)
        {
            new Add().Show();
            Close();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }



        private void objRemov_Click(object sender, RoutedEventArgs e)
        {
            db.Cars.Remove((Car)BdCars.SelectedItem);
            db.SaveChanges();
            db.Cars.Load();
        }


        private void FormatTable(dynamic table)
        {
            dynamic borders = table.Borders;
            //wdBorderLeft
            borders[-2].LineStyle = 1;//wdLineStyleSingle
            borders[-2].LineWidth = 12;//wdLineWidth150pt
            borders[-2].Color = -16777216;
            //wdBorderRight
            borders[-4].LineStyle = 1;//wdLineStyleSingle
            borders[-4].LineWidth = 12;//wdLineWidth150pt
            borders[-4].Color = -16777216;
            //wdBorderTop
            borders[-1].LineStyle = 1;//wdLineStyleSingle
            borders[-1].LineWidth = 12;//wdLineWidth150pt
            borders[-1].Color = -16777216;
            //wdBorderBottom
            borders[-3].LineStyle = 1;//wdLineStyleSingle
            borders[-3].LineWidth = 12;//wdLineWidth150pt
            borders[-3].Color = -16777216;
            //wdBorderHorizontal
            borders[-5].LineStyle = 1;//wdLineStyleSingle
            borders[-5].LineWidth = 6;//wdLineWidth075pt 
            borders[-5].Color = -16777216;
            //wdBorderVertical
            borders[-6].LineStyle = 1;//wdLineStyleSingle
            borders[-6].LineWidth = 12;//wdLineWidth150pt
            borders[-6].Color = -16777216;
        }

        private void otchet_Click(object sender, RoutedEventArgs e)
        {
            BdCars.SelectAllCells();
            BdCars.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
            ApplicationCommands.Copy.Execute(null, BdCars);
            BdCars.UnselectAllCells();
            var result = (string)Clipboard.GetData(DataFormats.Text);
            dynamic wordApp = null;
            try
            {
                var sw = new StreamWriter("export.doc");
                sw.WriteLine(result);
                sw.Close();
                //var proc = Process.Start("export.doc");
                Type wordType = Type.GetTypeFromProgID("Word.Application");
                wordApp = Activator.CreateInstance(wordType);
                wordApp.Documents.Add(System.AppDomain.CurrentDomain.BaseDirectory + "export.doc");
                // wordApp.ActiveDocument.Range.ConvertToTable(1, BdCars.Items.Count, BdCars.Columns.Count);
                dynamic wdTable = wordApp.ActiveDocument.Range.ConvertToTable(1, BdCars.Items.Count, BdCars.Columns.Count);
                FormatTable(wdTable);
                wordApp.Visible = true;
            }
            catch (Exception ex)
            {
                if (wordApp != null)
                {
                    wordApp.Quit();
                }
                // ignored
            }
        }

        private void not_Click(object sender, RoutedEventArgs e)
        {
          Car carTemp =  (Car)BdCars.SelectedItem;
            int index = carTemp.id;
            new Print(index).Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Car carTemp = (Car)BdCars.SelectedItem;
            int index = carTemp.id;
            new PrintTwo(index).Show();
        }
    }
}
