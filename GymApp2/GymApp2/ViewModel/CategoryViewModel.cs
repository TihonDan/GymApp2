using GymApp.Helpers;
using GymApp.Model;
using GymApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace GymApp.ViewModels
{
    public class CategoryViewModel : BaseModel
    {
        private Category _SelectedCategory;
        public Category SelectedCategory
        {
            set
            {
                _SelectedCategory = value;
                OnPropertyChanged();
            }
            get
            {
                return _SelectedCategory;
            }

            
        }
        public ObservableCollection<Exercises> ExercisesItemsByCategory { get; set; }

        public int _TotalExercisesItems;
        //private object latestExercisesItems;

        public int TotalExercisesItems
        {
            set
            {
                _TotalExercisesItems = value;
                OnPropertyChanged();
            }
            get
            {
                return _TotalExercisesItems;
            }
        }

        public CategoryViewModel(Category category)
        {
            SelectedCategory = category;
            ExercisesItemsByCategory = new ObservableCollection<Exercises>();
            GetExerciseItems(category.CategoryID);
        }

        private async void GetExerciseItems(int categoryID)
        {
            var data = await new ExerciseDataSerbice().GetExercisesByCategoryAsync(categoryID);
            ExercisesItemsByCategory.Clear();
            foreach(var item in data)
            {
                ExercisesItemsByCategory.Add(item);
            }
            TotalExercisesItems = ExercisesItemsByCategory.Count;
        }
    }
}
