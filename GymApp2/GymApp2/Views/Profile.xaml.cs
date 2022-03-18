using GymApp.ViewModels;
using GymApp2.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GymApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Profile : ContentView
    {
        public Profile()
        {
            InitializeComponent();
            //im.Source = ImageSource.FromResource("GymApp.welcomeBackFon.jpg");
        }

        private async void btn1_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}