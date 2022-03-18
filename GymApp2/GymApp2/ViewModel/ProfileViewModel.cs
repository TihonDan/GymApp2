using Firebase.Database;
using GymApp.Model;
using GymApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace GymApp2.ViewModel
{

    class ProfileViewModel : BaseModel
    {
        FirebaseClient client;
        private string _Username;
        public string Username
        {
            set
            {
                this._Username = value;
                OnPropertyChanged();
            }
            get
            {
                return this._Username;
            }


        }


        private string _Age;
        public string Age
        {
            set
            {
                this._Age = value;
                OnPropertyChanged();
            }
            get
            {
                return this._Age;
            }


        }

        private string _Height;
        public string Height
        {
            set
            {
                this._Height = value;
                OnPropertyChanged();
            }
            get
            {
                return this._Height;
            }


        }

        private string _Weight;
        public string Weight
        {
            set
            {
                this._Weight = value;
                OnPropertyChanged();
            }
            get
            {
                return this._Weight;
            }


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


        public Command User { get; set; }
        public ProfileViewModel()
        {
            client = new FirebaseClient("https://gymapp-42c7a-default-rtdb.firebaseio.com/");
            UserKey();
            User = new Command(async () => await UserKey());
        }
        public async Task<User> UserKey()
        {
            string key = Preferences.Get("Key", String.Empty);
            var user = (await client.Child("Users").OnceAsync<User>()).Where(u => u.Key == key).FirstOrDefault();
            Username = user.Object.Username;
            Age = user.Object.Age;
            Weight = user.Object.Weight;
            Height = user.Object.Height;

            var training = (await client.Child("Score").OnceAsync<User>()).Where(u => u.Object.IdUser == key).ToList();
            Score = 0;
            foreach (var list in training)
            {
                Score += list.Object.Score;
            }

            return user.Object;

        }
    }
}
