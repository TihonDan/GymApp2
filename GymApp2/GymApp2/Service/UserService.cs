using Firebase.Database;
using System;
using GymApp.Model;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database.Query;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace GymApp.Services
{
    public class UserService
    {

        FirebaseClient client;

        public string _key;

        public UserService()
        {
            client = new FirebaseClient("https://gymapp-42c7a-default-rtdb.firebaseio.com/");

        }

        public async Task<bool> IsUserExists(string uname)
        {
            var user = (await client.Child("Users").OnceAsync<User>()).Where(u => u.Object.Username == uname).FirstOrDefault();

            

            return (user != null);
        }

        public async Task<bool> RegisterUser(string uname, string passwd, string age, string height, string weight)
        {
            if (await IsUserExists(uname) == false)
            {

                await client.Child("Users")
                    .PostAsync(new User()
                    {

                        Username = uname,
                        Password = passwd,
                        Age = age,
                        Height = height,
                        Weight = weight,
                        
                    });


                return true;
            }
            else
            {
                return false;
            }

        }

        public async Task<bool> LoginUser(string uname, string passwd)
        {
            var user = (await client.Child("Users")
                .OnceAsync<User>()).Where(u => u.Object.Username == uname)
                .Where(u => u.Object.Password == passwd).FirstOrDefault();
            Preferences.Set("Key", user.Key);
            _key = user.Object.Username;
            try
            {
                Console.WriteLine(Convert.ToString(_key));
            }
            catch
            {

            }
            return (user != null);
        }


    }
}
