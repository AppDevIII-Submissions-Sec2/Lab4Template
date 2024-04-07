using MauiFitness.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiFitness.DataRepos
{
    public class FitnessRepo
    {
        public ObservableCollection<Meal> MealsDb { get; set; } = new ObservableCollection<Meal>();
        public ObservableCollection<Workout> WorkoutDb { get; set; } = new ObservableCollection<Workout>();

    }
}
