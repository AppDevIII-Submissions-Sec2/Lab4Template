using MauiFitness.Converters;
using MauiFitness.Models;
using MauiFitness.Services;
namespace MauiFitness.Views;

public partial class WorkoutFormPage : ContentPage
{
    Workout workout_;
    Workout workoutCopy_;
    private EditorMode mode;

    enum EditorMode
    { 
        Add,
        Edit
    }
    public WorkoutFormPage(Workout item = null)
    {
        InitializeComponent();
        if(item != null )
        {
            mode = EditorMode.Edit;
            workout_ = item;
            workoutCopy_ = item.Copy();
        }
        else
        {
            mode = EditorMode.Add;
            workoutCopy_ = new Workout();
        }
        BindingContext = workoutCopy_;

    }


    private void DateTimePicker_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (workoutCopy_ != null)
            workoutCopy_.Time = new DateTime(
                datePicker.Date.Year,
                datePicker.Date.Month,
                datePicker.Date.Day,
                timePicker.Time.Hours,
                timePicker.Time.Minutes,
                timePicker.Time.Seconds
                );
    }

    private async void Btn_Done_Clicked(object sender, EventArgs e)
    {

        switch(mode)
        {
            case EditorMode.Add:
                App.Repo.WorkoutDb.Add(workoutCopy_);
                break;

            case EditorMode.Edit:
                var idx = App.Repo.WorkoutDb.IndexOf(workout_);
                App.Repo.WorkoutDb[idx] = workoutCopy_;

                // This:
                // workout_ = workoutCopy_;
                // will not notify the collection view that the item has changed
                // we must use the observable collection accessor to modify the item.
                break;
        }

        await Shell.Current.GoToAsync($"//{nameof(WorkoutsPage)}");
    }

    private async void Btn_Cancel_Clicked(object sender, EventArgs e)
    {
        // Does nothing, simply goes back to the previous page
        await Shell.Current.GoToAsync($"//{nameof(WorkoutsPage)}");
    }

   

    private async void Entry_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (workoutCopy_.Description != null)
        {
            var burntCalories =
                await WorkoutService.GetBurntCalories(workoutCopy_.Description);
            workoutCopy_.CalBurntPerHour = burntCalories;
        }
    }

}