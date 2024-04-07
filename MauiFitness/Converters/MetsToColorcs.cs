using System.Globalization;


namespace MauiFitness.Converters
{
    public class MetsToColor : IValueConverter
    {
        readonly int  MAX_CALORIES=1500;
        readonly int MIN_CALORIES = 0;
        readonly Color color1 = Colors.DarkOrange;
        readonly Color color2 = Colors.MediumVioletRed;


        public object Convert(object calories, Type targetType, object parameter, CultureInfo culture)
        {

            var percentage = MetsToPercentage((double)calories);
            var color = Color.FromRgb(
                                Interpolate(color1.Red, color2.Red, percentage),
                                Interpolate(color1.Green, color2.Green, percentage),
                                Interpolate(color1.Blue, color2.Blue, percentage));
            return color;
        }
        private double MetsToPercentage(double Mets)
        {
            return (Mets - MIN_CALORIES) / MAX_CALORIES;
        }
        private double Interpolate(double val1, double val2, double perc)
        {
            return val1 + (perc * (val2 - val1));
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return 1.0;
        }

    }

}
