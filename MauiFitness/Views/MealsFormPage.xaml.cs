using MauiFitness.DataRepos;
using MauiFitness.Models;
using MauiFitness.Services;

namespace MauiFitness.Views;

public partial class MealsFormPage : ContentPage
{
    private Meal _meal;
    public MealsFormPage()
	{
		InitializeComponent();
        Title = "New Meal";
        PickerMeal.ItemsSource = MealsIcons.Dict.Keys.ToList<string>();
        _meal = new Meal() { Time = DateTime.Now };
        BindingContext = _meal;
    }

    private async void Btn_GetMealInfo_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(entryDetails.Text))
        {
            return;
        }
        _meal.Calories = await MealsService.GetMealCalories(entryDetails.Text);
    }

    private void DateTimePicker_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if(_meal !=  null) 
        _meal.Time = new DateTime(
            datePicker.Date.Year,
            datePicker.Date.Month,
            datePicker.Date.Day,
            timePicker.Time.Hours,
            timePicker.Time.Minutes,
            timePicker.Time.Seconds
            );
    }

    private async void Btn_Save_Clicked(object sender, EventArgs e)
    {
        if(PickerMeal.SelectedIndex == -1)
        {
            await DisplayAlert("Missing Data", "Please pick a meal?", "OK");
            return;
        }
        App.Repo.MealsDb.Add(_meal);
        await Navigation.PopAsync();
    }

    private async void Btn_Cancel_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void EntryDetails_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (string.IsNullOrEmpty(entryDetails.Text))
        {
            await DisplayAlert("Missing Data", "Please fill in the food?", "OK");
            return;
        }
        var value = await MealsService.GetMealCalories(entryDetails.Text);

        if (value != null)
            _meal.Calories = value;
    }
}