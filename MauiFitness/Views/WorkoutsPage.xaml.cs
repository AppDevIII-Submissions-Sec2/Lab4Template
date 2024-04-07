namespace MauiFitness.Views;

using MauiFitness.Models;
using System.Collections.ObjectModel;
using System.Linq;


public partial class WorkoutsPage : ContentPage
{
    bool AreExercicesVisible = true;

   

    public WorkoutsPage()
    {
        InitializeComponent();
        WorkoutsCollection.ItemsSource = App.Repo.WorkoutDb;
    }

    async void btn_addWorkout_clicked(object sender, EventArgs e)
    {

        await Navigation.PushAsync(new WorkoutFormPage());
    }
    void btn_displayworkouts_clicked(object sender, EventArgs e)
    {
        AreExercicesVisible = !AreExercicesVisible;

        WorkoutsCollection.ItemsSource = AreExercicesVisible ?
            App.Repo.WorkoutDb : Enumerable.Empty<Workout>();
    }

    async void Swipe_Delete_Clicked(object sender, EventArgs e)
    {

        var item = (sender as SwipeItem).BindingContext;

        App.Repo.WorkoutDb.Remove(item as Workout);
    }

    private async void Swipe_Edit_Clicked(object sender, EventArgs e)
    {
        var item = (sender as SwipeItem).BindingContext;
        await Navigation.PushAsync(new WorkoutFormPage(item as Workout));
    }
}