
using System.Collections.Specialized;
using System.ComponentModel;


namespace MauiFitness.Models
{
    public class Meal : INotifyPropertyChanged
    {
        
        public event PropertyChangedEventHandler PropertyChanged;

        public string Name { get; set; }
        
        public string Description { get; set; }
             
      
        public DateTime Time { get; set; }

        private double _calories;


        public double Calories { 
            get => _calories;
            set
            { 
                if(value >= 0)
                {
                    _calories = value;
                }
            }
        }


    }


}
