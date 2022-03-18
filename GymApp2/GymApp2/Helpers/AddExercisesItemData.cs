using Firebase.Database;
using Firebase.Database.Query;
using GymApp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GymApp.Helpers
{
    public class AddExercisesItemData
    {
        public List<Exercises> ExercisesItems { get; set; }
        FirebaseClient client;

        public AddExercisesItemData()
        {
            client = new FirebaseClient("https://gymapp-42c7a-default-rtdb.firebaseio.com/");
            ExercisesItems = new List<Exercises>()
            {
                new Exercises//Для пресса
                {
                    ExercisesID = 1,
                    CategoryID = 2,
                    ImageURL = "Razminka.jpg",
                    Name = "Разминка",
                    Description = "Разминка",
                    Time = 20

                },

                new Exercises//Для пресса
                {
                    ExercisesID = 2,
                    CategoryID = 2,
                    ImageURL = "Press.jpg",
                    Name = "Скручивание лёжа x30",
                    Description = "Пресс",
                    Count = 30

                },

                new Exercises//Для пресса
                {
                    ExercisesID = 3,
                    CategoryID = 2,
                    ImageURL = "Velo.jpg",
                    Name = "Скручивание велосипедиста x20",
                    Description = "Пресс",
                    Count = 20

                },

                new Exercises//Для пресса
                {
                    ExercisesID = 4,
                    CategoryID = 2,
                    ImageURL = "Perecr.jpg",
                    Name = "Перекрёстные скручивания x20",
                    Description = "Пресс",
                    Count = 20

                },

                new Exercises//Для пресса
                {
                    ExercisesID = 5,
                    CategoryID = 2,
                    ImageURL = "Planka.jpeg",
                    Name = "Планка",
                    Description = "Пресс",
                    Time = 2

                },

                new Exercises//Для рук
                {
                    ExercisesID = 1,
                    CategoryID = 1,
                    ImageURL = "Razminka.jpg",
                    Name = "Разминка",
                    Description = "Разминка",
                    Time = 20,

                },

                new Exercises//Для рук
                {
                    ExercisesID = 2,
                    CategoryID = 1,
                    ImageURL = "Otjim.jpg",
                    Name = "Отжимания x20",
                    Description = "Отжимания",
                    Count = 20

                },

                new Exercises//Для рук
                {
                    ExercisesID = 3,
                    CategoryID = 1,
                    ImageURL = "Molotok.jpeg",
                    Name = "Молоток x15",
                    Description = "Молоток",
                    Count = 15

                },

                new Exercises//Для рук
                {
                    ExercisesID = 4,
                    CategoryID = 1,
                    ImageURL = "Razved.jpg",
                    Name = "Разведение гантелей x15",
                    Description = "Гантели",
                    Count = 15

                },

                new Exercises//Для рук
                {
                    ExercisesID = 5,
                    CategoryID = 1,
                    ImageURL = "GorizRazved.jpeg",
                    Name = "Горизонтальное разведение x15",
                    Description = "Гантели",
                    Count = 15

                },

                new Exercises//Для рук
                {
                    ExercisesID = 6,
                    CategoryID = 1,
                    ImageURL = "OtjimOtSkam.jpg",
                    Name = "Отжимания от скамьи x20",
                    Description = "Отжимания",
                    Count = 20

                },

                new Exercises//Для ног
                {
                    ExercisesID = 1,
                    CategoryID = 3,
                    ImageURL = "Razminka.jpg",
                    Name = "Разминка",
                    Description = "Разминка",
                    Time = 20

                },

                new Exercises//Для ног
                {
                    ExercisesID = 2,
                    CategoryID = 3,
                    ImageURL = "Prised.jpg",
                    Name = "Приседания x15",
                    Description = "Приседания",
                    Count = 15

                },

                new Exercises//Для ног
                {
                    ExercisesID = 3,
                    CategoryID = 3,
                    ImageURL = "VipadVper.jpe",
                    Name = "Выпады вперёд x10",
                    Description = "Делать выпады на каждую ногу",
                    Count = 10

                },

                new Exercises//Для ног
                {
                    ExercisesID = 4,
                    CategoryID = 3,
                    ImageURL = "VipadVbok.jpg",
                    Name = "Боковой выпад x10",
                    Description = "Делать выпады на каждую ногу",
                    Count = 10

                },

                new Exercises//Для ног
                {
                    ExercisesID = 5,
                    CategoryID = 3,
                    ImageURL = "DiagonalVipada.jpg",
                    Name = "Диагональные выпады x10",
                    Description = "Делать выпады на каждую ногу",
                    Count = 10

                },

                new Exercises//Для ног
                {
                    ExercisesID = 6,
                    CategoryID = 3,
                    ImageURL = "Maxi.jpg",
                    Name = "Махи ногами x10",
                    Description = "Делать выпады на каждую ногу",
                    Count = 10

                },


            };
        }

        public async Task AddExercisesItemAsync()
        {
            try
            {
                foreach (var item in ExercisesItems)
                {
                    await client.Child("Exercises").PostAsync(new Exercises()
                    {
                        ExercisesID = item.ExercisesID,
                        CategoryID = item.CategoryID,
                        ImageURL = item.ImageURL,
                        Name = item.Name,
                        Description = item.Description,
                        Count = item.Count,
                        Time = item.Time
                    });
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }

        }
    }
}
