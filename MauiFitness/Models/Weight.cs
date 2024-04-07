using System.ComponentModel;

namespace MauiFitness.Models
{

    public class Weight : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public static Weight HealthyMin = new Weight(50);
        public static Weight HealthyMax = new Weight(70);
        public static Weight ObesityLimit = new Weight(90);

        public enum WeightUnit
        {
            Kg,
            Ib
        }
        private double _value;
        private WeightUnit _unit;

        

        public double Value
        {
            get
            {
                return _value;
            }
            set
            {
                if (value > 0.0)
                {
                    _value = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }
        public WeightUnit Unit { 
            get { return _unit; }
            set { 
                if (!Enum.IsDefined(typeof(WeightUnit), value))
                {
                    throw new ArgumentOutOfRangeException();
                }
                else if(value != _unit)
                {
                    _unit = value;
                    ///\TODO: Conversion of the value if unit changed
                }

            } }

        public Weight(double value, WeightUnit unit = WeightUnit.Kg)
        {
            Value = value;
            Unit = unit;
        }
    }
}
