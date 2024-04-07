namespace MauiFitness.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

    private async void BtnLogin_Clicked(object sender, EventArgs e)
    {
        lblError.Text = string.Empty;
        if (user_name.Text == "user123" && password.Text == "12345")
        {
            //Update UI
            lblUser.Text = $"ID    : {user_name.Text}\n";
            LoginView.IsVisible = false;
            HomeView.IsVisible = true;
        }
        else
            lblError.Text = "Wrong Username or Password";
    }

    private async void LogoutBtn_Clicked(object sender, EventArgs e)
    {
        try
        {
            //Update UI
            lblUser.Text = string.Empty;
            HomeView.IsVisible = false;
            LoginView.IsVisible = true;
        }
        catch (Exception ex)
        {
            await DisplayAlert("Alert", ex.Message, "OK");
        }
    }
}