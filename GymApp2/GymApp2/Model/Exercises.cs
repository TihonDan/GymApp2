using System;
using System.Collections.Generic;
using System.Text;

namespace GymApp.Model
{
    public class Exercises
    {
        public int ExercisesID { get; set; }
        public int CategoryID { get; set; }
        public string ImageURL { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Count { get; set; }
        public int Time { get; set; }
        
    }
}
