using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HelloWorld
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            try
            {
                //var phone = DependencyService.Get<ICellPhone>();
                //phone.Call("0303030303");

                //Device.OpenUri(new Uri("tel:0303030303"));
                this.Navigation.PushAsync(new Page2());
            }
            catch(Exception ex)
            {
                
            }
            
        }

        /*private void ContentPage_Appearing(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }*/
    }

   
}
