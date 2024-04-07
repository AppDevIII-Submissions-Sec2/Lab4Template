using System.Collections.ObjectModel;

namespace MauiFitness.Views;
using Models;

public partial class MealsPage : ContentPage
{
    public MealsPage()
    {
        InitializeComponent();
        MealsCollection.ItemsSource = App.Repo.MealsDb;
    }

    private void btn_DisplayMeals_clicked(object sender, EventArgs e)
    {
        MealsCollection.ItemsSource =
           MealsCollection.ItemsSource == App.Repo.MealsDb
           ? Enumerable.Empty<Meal>() : App.Repo.MealsDb;
    }

    private async void btn_AddMeal_clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MealsFormPage());
    }

    private async void Swipe_Delete_Clicked(object sender, EventArgs e)
    {
        //Need confirmation
        Meal temp = (sender as SwipeItem).CommandParameter as Meal;
        bool result = await DisplayAlert($"Delete Meal", $"Are you sure you want to delete {temp.Name} from the list of meals?", "Yes", "No");
        if (result)
            App.Repo.MealsDb.Remove(temp);

    }
}