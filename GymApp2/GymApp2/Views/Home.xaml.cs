using GymApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using GymApp.Services;
using Firebase.Database;
using Xamarin.Essentials;
using GymApp.Helpers;
using GymApp2.ViewModel;

namespace GymApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentView
    {
        FirebaseClient client;

        UserService us = new UserService();

        ProfileViewModel prm = new ProfileViewModel();
        public Home()
        {
            client = new FirebaseClient("https://gymapp-42c7a-default-rtdb.firebaseio.com/");
            BindingContext = us;
            BindingContext = this;
            BindingContext = prm;
            InitializeComponent();  
        }


        private async void CollectionView_SelectionChanged(System.Object sender, Xamarin.Forms.SelectionChangedEventArgs e)
        {
            Category selectLang = e.CurrentSelection[0] as Category;

            await Navigation.PushModalAsync(new CategoryView(selectLang.CategoryID));

        }

    }
}