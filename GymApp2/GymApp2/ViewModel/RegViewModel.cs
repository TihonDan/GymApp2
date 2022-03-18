using GymApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace GymApp.ViewModels
{
    

    class RegViewModel 
    {
        public Command LoginViewCommand { get; set; }

        public RegViewModel()
        {
            LoginViewCommand = new Command(async() => await LoginViewAsync());
        }

        private async Task LoginViewAsync()
        {
            await Application.Current.MainPage.Navigation.PopModalAsync();
        }
    }

    

}
