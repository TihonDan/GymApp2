using GymApp.Model;
using GymApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace GymApp.ViewModels
{
    class ExercisesViewModel : BaseModel
    {
        private string _UserName;
        public string UserName
        {
            set
            {
                _UserName = value;
                OnPropertyChanged();
            }
            get
            {
                return _UserName;
            }
        }

        public ObservableCollection<Category> Categories { get; set; }

        public ExercisesViewModel()
        {
            Categories = new ObservableCollection<Category>();

            GetCategories();
        }

        private async void GetCategories()
        {
            var data = await new CategoryDataService().GetCategoriesAsync();
            Categories.Clear();
            foreach(var item in data)
            {
                Categories.Add(item);
            }
        }
    }
}
