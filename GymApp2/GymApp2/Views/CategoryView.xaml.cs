using Firebase.Database;
using Firebase.Database.Query;
using GymApp.Helpers;
using GymApp.Model;
using GymApp.ViewModels;
using GymApp2.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamTimer.ViewModel;

namespace GymApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoryView : ContentPage
    {
        FirebaseClient client;

        public int Count = 1;

        AddExercisesItemData exercises = new AddExercisesItemData();

        public static LoginViewModel score = new LoginViewModel();
        public int resScore;
        
        public ObservableCollection<Exercises> Items { get; set; }

        int ID;

        public CategoryViewModel _vm;

        TimerViewModel _timer = new TimerViewModel();

        public CategoryView(int id)
        {
            client = new FirebaseClient("https://gymapp-42c7a-default-rtdb.firebaseio.com/");

            ID = id;

            Items = new ObservableCollection<Exercises>();

            foreach (Exercises a in exercises.ExercisesItems)
            {
                if (a.CategoryID == ID)
                {
                    if(a.ExercisesID == Count)
                    {
                        Items.Add(a);
                    }
                }
            }
            InitializeComponent();
            BindingContext = this;
            BindingContext = _timer;
            SomeCollection.ItemsSource = Items;

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Items.Clear();
            Count++;
            foreach (Exercises a in exercises.ExercisesItems)
            {
                if (a.CategoryID == ID)
                {
                    if (a.ExercisesID == Count)
                    {
                        Items.Add(a);
                    }
                }
                
            }
            if (Count == 7)
            {
                UserKey();
                Navigation.PushModalAsync(new Congratulations());
            }
            labelSecond.IsEnabled = false;
            labelSecond.IsVisible = false;
            frameBtn.IsEnabled = false;
            frameBtn.IsVisible = false;
            btnPlay.IsEnabled = false;
            btnPlay.IsVisible = false;
            if (Count != 1)
            {
                btn1.IsEnabled = true;
                btn1.IsVisible = true;
            }
        }

        private void btn1_Clicked(object sender, EventArgs e)
        {
            Items.Clear();
            Count--;
            foreach(Exercises a in exercises.ExercisesItems)
            {
                if(a.CategoryID == ID)
                {
                    if(a.ExercisesID == Count)
                    {
                        Items.Add(a);
                    }
                }
            }
            if(Count == 1)
            {
                btn1.IsEnabled = false;
                btn1.IsVisible = false;
                labelSecond.IsEnabled = true;
                labelSecond.IsVisible = true;
                frameBtn.IsEnabled = true;
                frameBtn.IsVisible = true;
                btnPlay.IsEnabled = true;
                btnPlay.IsVisible = true;
            }
            else
            {
                btn1.IsEnabled = true;
                btn1.IsVisible = true;
            }

        }

        public async Task<bool> UserKey()
        {
            string key = Preferences.Get("Key", String.Empty);
            var user = (await client.Child("Users").OnceAsync<User>()).Where(u => u.Key == key).FirstOrDefault();

            DateTime dateTime = DateTime.Now;

            await client.Child("Score").PostAsync(new User() {IdUser = key, Score = 25, Time = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day) });

            return (user != null);


        }
    }
}