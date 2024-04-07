using System.ComponentModel;

namespace MauiFitness.Models
{    
    
    public class Workout : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        
        public string Name { get; set; }

        public string Description { get; set; }

       
        public DateTime Time { get; set; }
        public TimeSpan Duration { get; set; }


        public double CalBurntPerHour { get; set; }

        public double Calories
        {
            get => (Duration.TotalMinutes/60) * CalBurntPerHour;
        }

        //Copy method, for edit pusposes.
        public Workout Copy()
        {
            return new Workout()
            {
                Name = Name,
                Description = Description,
                Duration = Duration,
                CalBurntPerHour = CalBurntPerHour
            };
        }
    }
}
