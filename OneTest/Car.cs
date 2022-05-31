using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OneTest
{
    class Car: INotifyPropertyChanged
    {
        [Key]
        public int id { get; set; }

        private string organization, mark, number, add;


        public string Organization
        {
            get { return organization; }
            set { organization = value; OnPropertyChanged("Organization"); }
         }

    public string Mark
    {
        get { return mark; }
            set
            {
                mark = value;
            OnPropertyChanged("Mark");
        }
        }

    public string Number
    {
        get { return number; }
            set
            {
                number = value;
                OnPropertyChanged("Number");
            }
        }

    public string Add
    {
        get { return add; }
            set
            {
                add = value;
                OnPropertyChanged("Add");
            }
            
        }



        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public Car() { }

    public Car(string organization, string mark, string number, string add)
    {
        this.organization = organization;
        this.mark = mark;
        this.number = number;
        this.add = add;
    }
   
    }
}
