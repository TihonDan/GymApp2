using Firebase.Database;
using Firebase.Database.Query;
using GymApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace GymApp.Helpers
{
    public class AddCategoryData
    {
        public string name;
        public List<Category> Categories { get; set; }

        FirebaseClient client;

        public AddCategoryData()
        {
            client = new FirebaseClient("https://gymapp-42c7a-default-rtdb.firebaseio.com/");
            Categories = new List<Category>();

            Categories.Add(new Category()
            {
                CategoryID = 1,
                NameExercise = "Pump your hands",
                ExercisePoster = "MainОтжимания",
                ImageURL = "FonCategory2.jpg"
            });


            Categories.Add(new Category()
            {
                CategoryID = 2,
                NameExercise = "Pump your abs",
                ExercisePoster = "MainПресс",
                ImageURL = "FonCategory1.jpg"
            });


            Categories.Add(new Category()
            {
                CategoryID = 3,
                NameExercise = "Pump up your legs",
                ExercisePoster = "MainПриседания",
                ImageURL = "FonCategory3.jpg"
            });

        }

        public async Task AddCategoriesAsync()
        {
            // пример запроса на бек. необходимо посмотреть как делать post запрос
            //HttpClient _httpClient = new HttpClient();
            //await _httpClient.PostAsync("http://10.0.2.2:5000/category/addCategory");
            try
            {
                foreach (var category in Categories)
                {
                    await client.Child("Categories").PostAsync(new Category()
                    {
                        CategoryID = category.CategoryID,
                        NameExercise = category.NameExercise,
                        ExercisePoster = category.ExercisePoster,
                        ImageURL = category.ImageURL

                    });
                }
            }
            catch(Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }


    }
}
