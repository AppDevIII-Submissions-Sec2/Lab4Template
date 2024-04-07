using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiFitness.Models
{
    public class GoalWeight : INotifyPropertyChanged
    {
        public Weight CurrentWeight { get; set; }
        public Weight Goal { get; set; }
        public DateTime DueDate { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
