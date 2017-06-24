using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms;
using HelloWorld.Droid;

[assembly:Xamarin.Forms.Dependency(typeof(CellPhone))]
namespace HelloWorld.Droid
{
    class CellPhone : ICellPhone
    {
        public void Call(String number)
        {
            var intent = new Intent(Intent.ActionCall);
            intent.SetData(Android.Net.Uri.Parse("tel:" + number));
            Forms.Context.StartActivity(intent);
        }
    }
}