﻿using GymApp;
using GymApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GymApp2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Congratulations : ContentPage
    {
        public Congratulations()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage.Navigation.PushModalAsync(new AppShell());
        }
    }
}