using Firebase.Database;
using GymApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Services
{
    public class CategoryDataService
    {
        FirebaseClient client;

        public CategoryDataService()
        {
            client = new FirebaseClient("https://gymapp-42c7a-default-rtdb.firebaseio.com/");
        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            var categories = (await client.Child("Categories")
                .OnceAsync<Category>())
                .Select(c => new Category
                {
                    CategoryID = c.Object.CategoryID,
                    NameExercise = c.Object.NameExercise,
                    ExercisePoster = c.Object.ExercisePoster,
                    ImageURL = c.Object.ImageURL
                }).ToList();
            return categories;
        }
    }
}
