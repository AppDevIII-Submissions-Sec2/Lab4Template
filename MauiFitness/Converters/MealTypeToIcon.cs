using MauiFitness.DataRepos;
using MauiFitness.Models;
using System.Globalization;


namespace MauiFitness.Converters
{
    public class MealTypeToIcon : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value!=null && MealsIcons.Dict.ContainsKey(value.ToString()) )
            {
                return MealsIcons.Dict[value.ToString()];
            }
            else
            {
                return "";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return MealsIcons.Dict.FirstOrDefault(x => x.Value == value.ToString()).Key; 
        }
    }
}
