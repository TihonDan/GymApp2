using Firebase.Database;
using Firebase.Database.Query;
using GymApp.Model;
using GymApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace GymApp2.ViewModel
{
    class CalendarViewModel : BaseModel
    {
        FirebaseClient client;
        public DateTime dateTime = new DateTime();
        public CalendarViewModel()
        {
            client = new FirebaseClient("https://gymapp-42c7a-default-rtdb.firebaseio.com/");
            ScoreCount();
        }

        private int score;
        public int Score
        {
            set
            {
                this.score = value;
                OnPropertyChanged();
            }
            get
            {
                return this.score;
            }
        }

        public async Task<bool> ScoreCount()
        {
            string key = Preferences.Get("Key", String.Empty);

            var user = (await client.Child("Score").OnceAsync<User>()).Where(u => u.Object.IdUser == key).Where(u => u.Object.Time == SelectedDate).ToList();
            Score = 0;
            foreach (var list in user)
            {
                Score += list.Object.Score;
            }

            return (user != null);
        }
        private DateTime _selectedDate;
        public DateTime SelectedDate
        {
            get => _selectedDate;
            set => _selectedDate = value;
        }

        public ICommand SelectedDateCommand => new Command<DateTime>((selectedDate) =>
        {
            SelectedDate = selectedDate;
            ScoreCount();
        });


    }
}
