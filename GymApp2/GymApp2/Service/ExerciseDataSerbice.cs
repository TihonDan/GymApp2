using Firebase.Database;
using GymApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace GymApp.Services
{
    public class ExerciseDataSerbice
    {
        FirebaseClient client;

        public ExerciseDataSerbice()
        {
            client = new FirebaseClient("https://gymapp-42c7a-default-rtdb.firebaseio.com/");
        }

        public async Task<List<Exercises>> GetExercisesAsync()
        {
            var exercise = (await client.Child("ExercisesItems")
                .OnceAsync<Exercises>())
                .Select(e => new Exercises
                {
                    ExercisesID = e.Object.ExercisesID,
                    CategoryID = e.Object.CategoryID,
                    ImageURL = e.Object.ImageURL,
                    Name = e.Object.Name,
                    Description = e.Object.Description,
                    Count = e.Object.Count,
                    Time = e.Object.Time

                }).ToList();
            return exercise;
        }

        public async Task<ObservableCollection<Exercises>> GetExercisesByCategoryAsync(int categryID)
        {
            var exercisesItemByCategory = new ObservableCollection<Exercises>();
            var items = (await GetExercisesAsync()).Where(p => p.CategoryID == categryID).ToList();

            

            foreach (var item in items)
            {
                exercisesItemByCategory.Add(item);
            }
            return exercisesItemByCategory;
        }

        public async Task<ObservableCollection<Exercises>> GetLaresrExercisesAsync()
        {
            var latestExercisesItems = new ObservableCollection<Exercises>();
            var items = (await GetExercisesAsync()).OrderByDescending(f => f.ExercisesID).Take(3);
            foreach (var item in items)
            {
                latestExercisesItems.Add(item);
            }
            return latestExercisesItems;
        }
    }
}
