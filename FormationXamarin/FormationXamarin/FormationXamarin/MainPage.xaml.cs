using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FormationXamarin
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        private ObservableCollection<PhoneItem> phones;
        public ObservableCollection<PhoneItem> Phones { get => phones; set => phones = value; }
        public MainPage()
        {
            InitializeComponent();
            //DateCourante = DateTime.Now;
            phones = new ObservableCollection<PhoneItem> {new PhoneItem{Value="036587485965"}};
            this.BindingContext = this;
            //var label = new Label()
            //{
            //    Text = "Hello World",
            //    FontSize = 30,
            //    TextColor = Color.Red,
            //    BackgroundColor = Color.White
            //};

            //this.Content = label;
            //var paddingTop = Device.OnPlatform(20, 0, 0);
            //this.Padding = new Thickness(0,paddingTop,0,0);
        }

        //private void TapGestureRecognizer_OnTapped(object sender, EventArgs e)
        //{
        //    var randomGenerator = new Random();
        //    var nextRowIndex = randomGenerator.Next(0, 3);
        //    var nextColIndex = randomGenerator.Next(0, 3);

        //    freeBox.SetValue(Grid.RowProperty, nextRowIndex);
        //    freeBox.SetValue(Grid.ColumnProperty, nextColIndex);
        //}

        private async void Button_Clicked(object sender, EventArgs e)
        {
            //DateCourante = DateTime.Now;
            var newPhone = this.input.Text;
            this.Phones.Add(new PhoneItem{Value=newPhone});

            //HTTP
            var client = new HttpClient();
            var response = await client.GetAsync("http://www.google.com");
            var content = response.Content.ReadAsStringAsync();

        }

        //private DateTime dateCourante;

        //public DateTime DateCourante
        //{
        //    get { return this.dateCourante; }
        //    set
        //    {
        //        this.dateCourante = value;
        //        this.OnPropertyChanged("DateCourante");
        //    }
        //}
    }

    public class PhoneItem
    {
        public string Value { get; set; }
    }

    
}
