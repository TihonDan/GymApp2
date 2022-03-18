using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GymApp
{
    public partial class AppShell : TabbedPage
    {
        public AppShell()
        {
            InitializeComponent();

            
        }

        private async void ClickEvent_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Congratulations", "Button is working", "OK");
        }
    }
}